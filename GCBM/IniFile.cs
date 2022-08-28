﻿#region Using

/* 
 * Classe Gravar e Ler em um arquivo ini
 * 
 * Visite nossa página http://www.codigoexpresso.com.br
 * 
 * by Antonio Azevedo
 *  
 * public IniFile()
 *        Metodo construtor
 *        Pode-se informar string com Path (Caminho) + Nome do Arquivo separados ou em uma só string assim como não informar parametros
 *        Exemplo IniFile() , IniFile("C:\dados\exemplo","meuArquivo") ,  IniFile("C:\dados\exemplo\meuArquivo") , IniFile("meuArquivo")
 *        Se o Path (Caminho) não for informado será assumido o diretório da aplicação
 *        Se o nome do arquivo não for informado será assumido o mesmo nome da aplicacao com a extensão 'ini'
 *
 * public void IniWriteString()
 *        Gravar uma string no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será gerada com o mesmo nome da aplicacao, [Chave] e o [Valor]  
 *        Exemplo  IniWriteString("Sessao","Chave","Minha string") , IniWriteString("Chave","Minha string")
 *        
 * public void IniWriteInt()
 *        Gravar um inteiro no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será gerada com o mesmo nome da aplicacao, [Chave] e o [Valor]  
 *        Exemplo  IniWriteInt("Sessao","Chave",123456) , IniWriteString("Chave",123456)
 * 
 * public void IniWriteBool()
 *        Gravar um boolean (true/false) no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será gerada com o mesmo nome da aplicacao, [Chave] e o [Valor]  
 *        Exemplo  IniWriteBool("Sessao","Chave",true) , IniWriteString("Chave",true)
 *        
 * public string IniReadString()
 *        Ler uma string no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será considerada como o mesmo nome da aplicacao, [Chave] e o [Valor Default para retorno no caso de não existir]   
 *        Exemplo  IniReadString("Sessao","Chave","Meu valor default") , IniWriteString("Chave","Meu valor default")
 *
 * public Int32 IniReadInt()
 *        Ler uma string no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será considerada como o mesmo nome da aplicacao, [Chave] e o [Valor Default para retorno no caso de não existir]   
 *        Exemplo  IniReadInt("Sessao","Chave",0) , IniWriteString("Chave",0)
 *
 * public bool IniReadBool()
 *        Ler uma string no arquivo ini
 *        Informar [Sessao] podendo ser omitida e será considerada como o mesmo nome da aplicacao, [Chave] e o [Valor Default para retorno no caso de não existir]   
 *        Exemplo  IniReadBool("Sessao","Chave",false) , IniWriteString("Chave",false)
 */
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#endregion

namespace GCBM
{
    public class IniFile
    {
        #region Properties

        private string fileName { get; }

        // Define section e key default para os casos em que não se define.
        private readonly string section = Path.GetFileNameWithoutExtension(Application.ExecutablePath);


        // Declara dll para trabalhar com arquivos ini.
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        #endregion

        #region Construtor

        /// <summary>
        ///     Metodo Construtor onde se informa o Path (Caminho) e o Nome do Arquivo.
        /// </summary>
        /// <param name="path">Path (Caminho) onde sera gravado o arquivo</param>
        /// <param name="fileName">Nome do arquivo</param>
        /// <example>Inifile("C:\dados\exemplos","Configuracoes")</example>
        public IniFile(string path, string fileName)
        {
            if (path.Substring(path.Length - 1, 1) != Path.DirectorySeparatorChar.ToString())
            {
                path += Path.DirectorySeparatorChar;
            }

            this.fileName = path + corrigeFileName(fileName);
        }

        /// <summary>
        ///     Metodo Construtor onde se informa o Nome do Arquivo com ou sem Path (Caminho).
        ///     Se o Path (Caminho) não for informado será definido o Path (Caminho) da aplicação.
        /// </summary>
        /// <param name="fileName">[Path]+Nome do arquivo</param>
        /// <example>Inifile("Configuracoes") , Inifile("c:\dados\exemplos\Configuracoes")</example>
        public IniFile(string fileName)
        {
            if (fileName.IndexOf(Path.DirectorySeparatorChar) > -1)
            {
                this.fileName = fileName;
            }
            else
            {
                string strAppDir = Application.StartupPath;
                this.fileName = strAppDir + Path.DirectorySeparatorChar + corrigeFileName(fileName);
            }
        }

        /// <summary>
        ///     Metodo Construtor sem parametros.
        ///     O Path (Caminho) do arquivo será definido como o path (Caminho) da aplicacao.
        ///     O Nome do arquivo sera definido com o mesmo nome da aplicacao com a extensao '.ini'.
        /// </summary>
        /// <example>Inifile()</example>
        public IniFile()
        {
            string strAppDir = Application.ExecutablePath;
            strAppDir = strAppDir.ToLower().Replace(".exe", ".ini");
            fileName = strAppDir;
        }

        #region outros metodos

        /// <summary>
        ///     Corrige o nome do arquivo caso seja informado sem a extensão.
        /// </summary>
        /// <param name="fileName">string com o Nome do arquivo</param>
        /// <returns>string com o Nome do arquivo corrigido</returns>
        private string corrigeFileName(string fileName)
        {
            fileName = fileName.ToLower();
            if (fileName.IndexOf(".ini") == -1)
            {
                fileName += ".ini";
            }

            return fileName;
        }

        #endregion outros metodos

        #endregion Construtor

        #region Salvar no arquivo

        #region Salvar string

        /// <summary>
        ///     Grava string no arquivo ini.
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe a string a ser gravada</PARAM>
        public void IniWriteString(string Section, string Key, string Valor)
        {
            _ = WritePrivateProfileString(Section, Key, Valor, fileName);
        }

        /// <summary>
        ///     Grava string no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe a string a ser gravada</PARAM>
        public void IniWriteString(string Key, string Valor)
        {
            _ = WritePrivateProfileString(section, Key, Valor, fileName);
        }

        #endregion Salvar string

        #region Salvar inteiro

        /// <summary>
        ///     Grava inteiro no arquivo ini.
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe o inteiro a ser gravado</PARAM>
        public void IniWriteInt(string Section, string Key, int Valor)
        {
            _ = WritePrivateProfileString(Section, Key, Valor.ToString(), fileName);
        }

        /// <summary>
        ///     Grava inteiro no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe o inteiro a ser gravado</PARAM>
        public void IniWriteInt(string Key, int Valor)
        {
            _ = WritePrivateProfileString(section, Key, Valor.ToString(), fileName);
        }

        #endregion Salvar inteiro

        #region Salvar boolean

        /// <summary>
        ///     Grava boolean (true/false) no arquivo ini
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe o valor boolean a ser gravado</PARAM>
        public void IniWriteBool(string Section, string Key, bool Valor)
        {
            _ = WritePrivateProfileString(Section, Key, Valor.ToString(), fileName);
        }

        /// <summary>
        ///     Grava boolean (true/false) no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="Valor">Informe o valor boolean a ser gravado</PARAM>
        public void IniWriteBool(string Key, bool Valor)
        {
            _ = WritePrivateProfileString(section, Key, Valor.ToString(), fileName);
        }

        #endregion Salvar boolean

        #endregion Salvar no arquivo

        #region Ler o arquivo

        #region Ler string

        /// <summary>
        ///     Ler uma string no arquivo ini.
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor string default de retorno no caso de não existir</PARAM>
        /// <returns>string com valor</returns>
        public string IniReadString(string Section, string Key, string _default = "")
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(Section, Key, _default, temp,
                255, fileName);
            return temp.ToString();
        }

        /// <summary>
        ///     Ler uma string no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor string default de retorno no caso de não existir</PARAM>
        /// <returns>string com valor</returns>
        public string IniReadString(string Key, string _default = "")
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(section, Key, _default, temp,
                255, fileName);
            return temp.ToString();
        }

        #endregion Ler string

        #region Ler inteiro

        /// <summary>
        ///     Ler um inteiro no arquivo ini.
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor inteiro default de retorno no caso de não existir</PARAM>
        /// <returns>inteiro com valor</returns>
        public int IniReadInt(string Section, string Key, int _default = 0)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(Section, Key, _default.ToString(), temp,
                255, fileName);
            int valor;
            try
            {
                valor = Convert.ToInt32(temp.ToString());
            }
            catch
            {
                valor = _default;
            }

            return valor;
        }

        /// <summary>
        ///     Ler um inteiro no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor inteiro default de retorno no caso de não existir</PARAM>
        /// <returns>inteiro com valor</returns>
        public int IniReadInt(string Key, int _default = 0)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(section, Key, _default.ToString(), temp,
                255, fileName);
            int valor;
            try
            {
                valor = Convert.ToInt32(temp.ToString());
            }
            catch
            {
                valor = _default;
            }

            return valor;
        }

        #endregion Ler inteiro

        #region Ler boolean

        /// <summary>
        ///     Ler um boolean (true/false) no arquivo ini.
        /// </summary>
        /// <PARAM name="Section">Informe o nome sessão</PARAM>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor boolean (true/false) default de retorno no caso de não existir</PARAM>
        /// <returns>boolean com valor</returns>
        public bool IniReadBool(string Section, string Key, bool _default = false)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(Section, Key, _default.ToString(), temp,
                255, fileName);
            bool valor;
            try
            {
                valor = Convert.ToBoolean(temp.ToString());
            }
            catch
            {
                valor = _default;
            }

            return valor;
        }

        /// <summary>
        ///     Ler um boolean (true/false) no arquivo ini.
        /// </summary>
        /// <PARAM name="Key">Informe o nome da chave</PARAM>
        /// <PARAM name="_default">Informe o valor boolean (true/false) default de retorno no caso de não existir</PARAM>
        /// <returns>boolean com valor</returns>
        public bool IniReadBool(string Key, bool _default = false)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(section, Key, _default.ToString(), temp,
                255, fileName);
            bool valor;
            try
            {
                valor = Convert.ToBoolean(temp.ToString());
            }
            catch
            {
                valor = _default;
            }

            return valor;
        }

        #endregion Ler boolean

        #endregion Ler o arquivo
    }
}