using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCBM
{

}
//    public enum ChunkMode
//    {
//        CHUNK_MODE_ANY,      // allow any values
//        CHUNK_MODE_32KIB,    // force multiple of 32KiB
//        CHUNK_MODE_POW2,     // force multiple of 32KiB and power of 2
//        CHUNK_MODE_ISO,      // force values good for iso images and loaders
//    }

//    public class CISOOptions
//    {
//        public ChunkMode OptChunkMode { get; set; }
//        public uint OptChunkSize { get; set; }
//        public bool ForceChunkSize { get; set; }
//        public uint OptMaxChunks { get; set; }
//    }

//    public static class CISOConstants
//    {
//        public const int GiB = (1024 * 1024 * 1024);
//        public const int CISO_HEAD_SIZE = 0x8000;
//        public const int CISO_MAP_SIZE = CISO_HEAD_SIZE - 8;
//        public const int CISO_MIN_BLOCK_SIZE = 0x8000;
//        public const uint CISO_MAX_BLOCK_SIZE = 0x80000000;
//        public const int CISO_WR_MIN_BLOCK_SIZE = 1 * 1024 * 1024;
//        public const int CISO_WR_MAX_BLOCK = 0x2000;
//        public const int CISO_WR_MIN_HOLE_SIZE = 0x1000;
//        public const ushort CISO_UNUSED_BLOCK = ushort.MaxValue;
//        public const int WII_SECTORS_SINGLE_LAYER = 143432;
//        public const int WII_SECTORS_DOUBLE_LAYER = 2 * WII_SECTORS_SINGLE_LAYER;
//        public const int WII_MAX_SECTORS = WII_SECTORS_DOUBLE_LAYER;
//        public const int WII_SECTOR_SIZE_SHIFT = 15;
//        public const int WII_SECTOR_SIZE = 1 << WII_SECTOR_SIZE_SHIFT;

//    }

//    public class CISOHead
//    {
//        public byte[] Magic { get; set; }
//        public uint BlockSize { get; set; }
//        public byte[] Map { get; set; }

//        public CISOHead()
//        {
//            Magic = new byte[4];
//            Map = new byte[CISOConstants.CISO_MAP_SIZE];
//        }
//    }

//    public class CISOInfo
//    {
//        public uint BlockSize { get; set; }
//        public uint UsedBlocks { get; set; }
//        public uint NeededBlocks { get; set; }
//        public uint MapSize { get; set; }
//        public ushort[] Map { get; set; }
//        public long MaxFileOff { get; set; }
//        public long MaxVirtOff { get; set; }
//    }
//    public class CISOUtils
//    {
//        public static int ScanChunkMode(string source)
//        {
//            var tab = new (ChunkMode, string)[]
//            {
//                (ChunkMode.CHUNK_MODE_ISO, "ISO"),
//                (ChunkMode.CHUNK_MODE_POW2, "POW2"),
//                (ChunkMode.CHUNK_MODE_32KIB, "32KIB"),
//                (ChunkMode.CHUNK_MODE_ANY, "ANY")
//            };

//            foreach (var (id, keyword) in tab)
//            {
//                if (string.Equals(source, keyword, StringComparison.OrdinalIgnoreCase))
//                {
//                    CISOOptions options = new CISOOptions();
//                    options.OptChunkMode = id;
//                    return 0;
//                }
//            }

//            Console.Error.WriteLine($"Illegal chunk mode (option --chunk-mode): '{source}'");
//            return 1;
//        }

//        public static int ScanChunkSize(string source)
//        {
//            source = source.TrimStart();
//            bool forceChunkSize = source.StartsWith("=");
//            if (forceChunkSize)
//            {
//                source = source.Substring(1);
//            }

//            CISOOptions options = new CISOOptions();
//            uint chunkSize;
//            if (ScanSizeOptU32(source, 1, 0, "chunk-size", 0, CISOConstants.CISO_MAX_BLOCK_SIZE, 1, 0, true, out chunkSize) == 0)
//            {
//                options.OptChunkSize = chunkSize;
//                options.ForceChunkSize = forceChunkSize;
//                return 0;
//            }

//            return 1;
//        }

//        public static int ScanMaxChunks(string source)
//        {
//            CISOOptions options = new CISOOptions();
//            uint maxChunks;
//            if (ScanSizeOptU32(source, 1, 0, "max-chunks", 0, CISOConstants.CISO_MAP_SIZE, 1, 0, true, out maxChunks) == 0)
//            {
//                options.OptMaxChunks = maxChunks;
//                return 0;
//            }

//            return 1;
//        }

//        public static uint CalcBlockSizeCISO(out uint resultNBlocks, long fileSize)
//        {
//            CISOOptions options = new CISOOptions();

//            Console.WriteLine($"CalcBlockSizeCISO(,{(ulong)fileSize:x}) mode={options.OptChunkMode}, size={options.OptChunkSize:x}{(options.ForceChunkSize ? "!" : "")}, min={options.OptMaxChunks:x}");

//            if (fileSize == 0)
//            {
//                fileSize = 12L * (long)CISOConstants.GiB;
//            }

//            if (options.OptChunkMode >= ChunkMode.CHUNK_MODE_ISO)
//            {
//                ulong temp = CISOConstants.WII_MAX_SECTORS * (ulong)CISOConstants.WII_SECTOR_SIZE;
//                if ((ulong)fileSize < temp)
//                {
//                    fileSize = (long)temp;
//                }
//            }

//            Console.WriteLine($" - file_size  := {(ulong)fileSize:x}");

//            ulong blockSize = options.OptChunkSize;
//            if (blockSize == 0 || !options.ForceChunkSize)
//            {
//                uint maxBlocks = options.OptMaxChunks > 0
//                    ? options.OptMaxChunks
//                    : options.OptChunkMode >= ChunkMode.CHUNK_MODE_ISO
//                        ? Convert.ToUInt32(CISOConstants.CISO_WR_MAX_BLOCK)
//                        : Convert.ToUInt32(CISOConstants.CISO_MAP_SIZE);
//                Console.WriteLine($" - max_blocks := {maxBlocks:x}={maxBlocks}");

//                ulong temp = ((ulong)fileSize + maxBlocks - 1) / maxBlocks;
//                if (blockSize < temp)
//                {
//                    blockSize = temp;
//                    Console.WriteLine($" - {blockSize:x8} minimal block_size");
//                }

//                temp = ((ulong)fileSize + maxBlocks) / maxBlocks;
//                if (blockSize < temp)
//                {
//                    blockSize = temp;
//                    Console.WriteLine($" - {blockSize:x8} new block_size [max_blocks]");
//                }

//                uint factor = options.OptChunkMode >= ChunkMode.CHUNK_MODE_ISO
//                    ? CISOConstants.CISO_WR_MIN_BLOCK_SIZE
//                    : options.OptChunkSize < CISOConstants.CISO_MIN_BLOCK_SIZE
//                        ? options.OptChunkSize
//                        : CISOConstants.CISO_MIN_BLOCK_SIZE;
//                Console.WriteLine($" - factor := {factor:x}");

//                blockSize = (blockSize + factor - 1) / factor * factor;
//                Console.WriteLine($" - {blockSize:x8} aligned block_size [*{factor:x}]");

//                if (options.OptChunkMode >= ChunkMode.CHUNK_MODE_POW2)
//                {
//                    ulong refVal = blockSize;
//                    blockSize = CISOConstants.CISO_MIN_BLOCK_SIZE;
//                    while (blockSize < refVal)
//                    {
//                        blockSize <<= 1;
//                    }
//                    Console.WriteLine($" - {blockSize:x8} power 2");
//                }
//            }

//            if (blockSize > CISOConstants.CISO_MAX_BLOCK_SIZE)
//            {
//                blockSize = CISOConstants.CISO_MAX_BLOCK_SIZE;
//                Console.WriteLine($" - {blockSize:x8} cut di max");
//            }

//            ulong nBlocks = ((ulong)fileSize + blockSize - 1) / blockSize;
//            resultNBlocks = nBlocks < uint.MaxValue ? (uint)nBlocks : uint.MaxValue;
//            return (uint)blockSize;
//        }


//    }
//    public static class CISOSupport
//    {
//        public enum EnumError
//        {
//            //-------------------------------------------------------------------
//            ERR_OK,         // 100% success; below = warnings
//                            //-------------------------------------------------------------------

//            ERU_DIFFER,
//            ERR_DIFFER,
//            ERU_NOTHING_TO_DO,
//            ERR_NOTHING_TO_DO,
//            ERU_SOURCE_FOUND,
//            ERR_SOURCE_FOUND,
//            ERU_NO_SOURCE_FOUND,
//            ERR_NO_SOURCE_FOUND,
//            ERU_JOB_IGNORED,
//            ERR_JOB_IGNORED,
//            ERU_SUBJOB_WARNING,
//            ERR_SUBJOB_WARNING,
//            ERU_NOT_EXISTS,
//            ERR_NOT_EXISTS,

//            ERU_WARN_00,
//            ERU_WARN_01,
//            ERU_WARN_02,
//            ERU_WARN_03,
//            ERU_WARN_04,
//            ERU_WARN_05,
//            ERU_WARN_06,
//            ERU_WARN_07,
//            ERU_WARN_08,
//            ERU_WARN_09,
//            ERU_WARN_10,
//            ERU_WARN_XX,

//            //-------------------------------------------------------------------
//            ERU_WARNING,
//            ERR_WARNING,    // separator: below = real errors and not warnings
//                            //-------------------------------------------------------------------

//            ERR_NO_CISO,
//            ERR_CISO_INVALID,
//            ERU_WRONG_FILE_TYPE,
//            ERR_WRONG_FILE_TYPE,
//            ERU_INVALID_FILE,
//            ERR_INVALID_FILE,
//            ERU_INVALID_VERSION,
//            ERR_INVALID_VERSION,
//            ERU_INVALID_DATA,
//            ERR_INVALID_DATA,

//            ERU_ERROR1_00,
//            ERU_ERROR1_01,
//            ERU_ERROR1_02,
//            ERU_ERROR1_03,
//            ERU_ERROR1_04,
//            ERU_ERROR1_05,
//            ERU_ERROR1_06,
//            ERU_ERROR1_07,
//            ERU_ERROR1_08,
//            ERU_ERROR1_09,
//            ERU_ERROR1_10,
//            ERU_ERROR1_11,
//            ERU_ERROR1_12,
//            ERU_ERROR1_13,
//            ERU_ERROR1_14,
//            ERU_ERROR1_15,
//            ERU_ERROR1_16,
//            ERU_ERROR1_17,
//            ERU_ERROR1_18,
//            ERU_ERROR1_19,
//            ERU_ERROR1_20,
//            ERU_ERROR1_XX,

//            ERU_ENCODING,
//            ERR_ENCODING,
//            ERU_DECODING,
//            ERR_DECODING,
//            ERU_ALREADY_EXISTS,
//            ERR_ALREADY_EXISTS,
//            ERU_SUBJOB_FAILED,
//            ERR_SUBJOB_FAILED,

//            ERR_CANT_REMOVE,
//            ERU_CANT_REMOVE,
//            ERU_CANT_RENAME,
//            ERR_CANT_RENAME,
//            ERU_CANT_CLOSE,
//            ERR_CANT_CLOSE,
//            ERU_CANT_CONNECT,
//            ERR_CANT_CONNECT,
//            ERU_CANT_OPEN,
//            ERR_CANT_OPEN,
//            ERU_CANT_APPEND,
//            ERR_CANT_APPEND,
//            ERU_CANT_CREATE,
//            ERR_CANT_CREATE,
//            ERU_CANT_CREATE_DIR,
//            ERR_CANT_CREATE_DIR,

//            ERU_READ_FAILED,
//            ERR_READ_FAILED,
//            ERU_REMOVE_FAILED,
//            ERR_REMOVE_FAILED,
//            ERU_WRITE_FAILED,
//            ERR_WRITE_FAILED,
//            ERU_DATABASE,
//            ERR_DATABASE,

//            ERU_ERROR2_00,
//            ERU_ERROR2_01,
//            ERU_ERROR2_02,
//            ERU_ERROR2_03,
//            ERU_ERROR2_04,
//            ERU_ERROR2_05,
//            ERU_ERROR2_06,
//            ERU_ERROR2_07,
//            ERU_ERROR2_08,
//            ERU_ERROR2_09,
//            ERU_ERROR2_10,
//            ERU_ERROR2_XX,

//            ERU_MISSING_PARAM,
//            ERR_MISSING_PARAM,
//            ERU_SEMANTIC,
//            ERR_SEMANTIC,
//            ERU_SYNTAX,
//            ERR_SYNTAX,

//            ERU_INTERRUPT,
//            ERR_INTERRUPT,

//            //-------------------------------------------------------------------
//            ERU_ERROR,
//            ERR_ERROR,  // separator: below = hard/fatal errors => exit
//                        //-------------------------------------------------------------------

//            ERU_NOT_IMPLEMENTED,
//            ERR_NOT_IMPLEMENTED,
//            ERU_INTERNAL,
//            ERR_INTERNAL,

//            ERU_FATAL_00,
//            ERU_FATAL_01,
//            ERU_FATAL_02,
//            ERU_FATAL_03,
//            ERU_FATAL_04,
//            ERU_FATAL_XX,

//            ERU_OUT_OF_MEMORY,
//            ERR_OUT_OF_MEMORY,

//            //-------------------------------------------------------------------
//            ERU_FATAL,
//            ERR_FATAL,
//            //-------------------------------------------------------------------

//            ERR__N

//        }

//        public static EnumError InitializeCISO(CISOInfo ci, CISOHead ch)
//        {
//            if (ci == null)
//                throw new ArgumentNullException(nameof(ci));

//            ResetCISO(ci);
//            return SetupCISO(ci, ch);
//        }

//        public static EnumError SetupCISO(CISOInfo ci, CISOHead ch)
//        {
//            if (ci == null)
//                throw new ArgumentNullException(nameof(ci));

//            ResetCISO(ci);
//            if (ch == null)
//                return EnumError.ERR_OK;

//            if (!ch.Magic.SequenceEqual(Encoding.ASCII.GetBytes("CISO")))
//                return EnumError.ERR_NO_CISO;

//            uint blockSize = BitConverter.ToUInt32(BitConverter.GetBytes(ch.BlockSize).Reverse().ToArray(), 0);

//            if (blockSize < CISOConstants.CISO_MIN_BLOCK_SIZE || (blockSize & (CISOConstants.CISO_MIN_BLOCK_SIZE - 1)) != 0)
//                return EnumError.ERR_CISO_INVALID;

//            uint usedBlocks = 0;
//            int neededBlocks = 0;

//            for (int i = 0; i < ch.Map.Length; i++)
//            {
//                if (ch.Map[i] == 1)
//                {
//                    neededBlocks = i + 1;
//                    usedBlocks++;
//                }
//                else if (ch.Map[i] != 0)
//                {
//                    ResetCISO(ci);
//                    return EnumError.ERR_CISO_INVALID;
//                }
//            }

//            ci.BlockSize = blockSize;
//            ci.UsedBlocks = usedBlocks;
//            ci.NeededBlocks = (uint)neededBlocks;
//            ci.MaxFileOff = (long)(blockSize * usedBlocks + CISOConstants.CISO_HEAD_SIZE);
//            ci.MaxVirtOff = (long)(blockSize * ci.NeededBlocks);

//            if (ci.NeededBlocks > 0)
//            {
//                ci.MapSize = ci.NeededBlocks;
//                ci.Map = new ushort[ci.MapSize];

//                ushort mcount = 0;
//                for (int i = 0; i < ci.MapSize; i++)
//                {
//                    ci.Map[i] = ch.Map[i] != 0 ? mcount++ : CISOConstants.CISO_UNUSED_BLOCK;
//                }
//            }

//            return EnumError.ERR_OK;
//        }

//        public static void ResetCISO(CISOInfo ci)
//        {
//            if (ci == null)
//                throw new ArgumentNullException(nameof(ci));

//            if (ci.Map != null)
//                ci.Map = null;

//            ci.BlockSize = 0;
//            ci.UsedBlocks = 0;
//            ci.NeededBlocks = 0;
//            ci.MapSize = 0;
//            ci.MaxFileOff = 0;
//            ci.MaxVirtOff = 0;
//        }

//        public static EnumError SetupReadCISO(SuperFile sf)
//        {
//            if (sf == null)
//                throw new ArgumentNullException(nameof(sf));

//            CISOInfo ci = sf.Ciso;
//            if (ci.Map != null)
//                return EnumError.ERR_OK;

//            CleanSF(sf);

//            CISOHead ch;
//            EnumError err = ReadAtF(sf.F, 0, out ch);
//            if (err != EnumError.ERR_OK)
//                return err;

//            if (SetupCISO(ci, ch) != EnumError.ERR_OK)
//                return EnumError.ERR_CISO_INVALID;

//            long minSize = (long)CISOConstants.WII_SECTORS_SINGLE_LAYER * CISOConstants.WII_SECTOR_SIZE;

//            sf.FileSize = ci.MaxVirtOff > minSize ? ci.MaxVirtOff : minSize;
//            sf.F.MaxOff = ci.MaxFileOff;
//            sf.MaxVirtOff = ci.MaxVirtOff;
//            SetupIOD(sf, OpenFileType.OFT_CISO, OpenFileType.OFT_CISO);

//            return EnumError.ERR_OK;
//        }

//        public static EnumError ReadCISO(SuperFile sf, long off, byte[] buf, int count)
//        {
//            if (sf == null)
//                throw new ArgumentNullException(nameof(sf));

//            CISOInfo ci = sf.Ciso;
//            if (ci.Map == null)
//                return ReadAtF(sf.F, off, buf, count);

//            if (ci.BlockSize == 0)
//                throw new InvalidOperationException("Block size must be set.");

//            ulong blockSize = ci.BlockSize;
//            int bufIndex = 0;
//            uint block = (uint)((ulong)off / blockSize);
//            while (count > 0)
//            {
//                if (block >= ci.MapSize)
//                {
//                    Array.Clear(buf, bufIndex, count);
//                    return EnumError.ERR_OK;
//                }

//                long beg = off - (long)(block * blockSize);
//                if (beg < 0)
//                    throw new InvalidOperationException("Unexpected negative offset.");

//                int size = (int)(blockSize - (ulong)beg);
//                if (size > count)
//                    size = count;

//                ushort rdBlock = ci.Map[block];

//                if (rdBlock == CISOConstants.CISO_UNUSED_BLOCK)
//                {
//                    Array.Clear(buf, bufIndex, size);
//                }
//                else
//                {
//                    EnumError err = ReadAtF(sf.F, (long)(rdBlock * blockSize + CISOConstants.CISO_HEAD_SIZE + (ulong)beg), buf, bufIndex, size);
//                    if (err != EnumError.ERR_OK)
//                        return err;
//                }

//                off += size;
//                bufIndex += size;
//                count -= size;
//                block++;
//            }

//            return EnumError.ERR_OK;
//        }
//        public static long DataBlockCISO(SuperFile sf, long off, int hintAlign, out long blockSize)
//        {
//            if (sf == null)
//                throw new ArgumentNullException(nameof(sf));

//            CISOInfo ci = sf.Ciso;
//            if (ci.Map == null || ci.BlockSize == 0)
//                throw new InvalidOperationException("Map and block size must be set.");

//            ulong cisoBlockSize = ci.BlockSize;
//            uint block = (uint)((ulong)off / cisoBlockSize);

//            while (block < ci.MapSize && ci.Map[block] == CISOConstants.CISO_UNUSED_BLOCK)
//            {
//                block++;
//            }

//            if (block >= ci.MapSize)
//            {
//                blockSize = 0;
//                return DataBlockStandard(sf, off, hintAlign, out blockSize);
//            }

//            long off1 = (long)(block * cisoBlockSize);
//            if (off < off1)
//                off = off1;

//            if (block < ci.MapSize && ci.Map[block] != CISOConstants.CISO_UNUSED_BLOCK)
//            {
//                while (block < ci.MapSize && ci.Map[block] != CISOConstants.CISO_UNUSED_BLOCK)
//                {
//                    block++;
//                }
//                blockSize = (long)(block * cisoBlockSize - (ulong)off);
//            }
//            else
//            {
//                blockSize = 0;
//            }

//            return off;
//        }

//        public static void FileMapCISO(SuperFile sf, FileMap fm)
//        {
//            if (sf == null)
//                throw new ArgumentNullException(nameof(sf));
//            if (fm == null)
//                throw new ArgumentNullException(nameof(fm));

//            CISOInfo ci = sf.Ciso;
//            if (ci.Map == null || ci.BlockSize == 0)
//                throw new InvalidOperationException("Map and block size must be set.");

//            ulong cisoBlockSize = ci.BlockSize;
//            ulong cisoOff = CISOConstants.CISO_HEAD_SIZE;

//            for (uint block = 0; block < ci.MapSize; block++)
//            {
//                if (ci.Map[block] != CISOConstants.CISO_UNUSED_BLOCK)
//                {
//                    AppendFileMap(fm, block * cisoBlockSize, cisoOff, cisoBlockSize);
//                    cisoOff += cisoBlockSize;
//                }
//            }
//        }

//        public static EnumError WriteCISO(SuperFile sf, long off, byte[] buf, int count)
//        {
//            if (sf == null)
//                throw new ArgumentNullException(nameof(sf));

//            CISOInfo ci = sf.Ciso;
//            if (ci.Map == null)
//                return WriteAtF(sf.F, off, buf, count);

//            if (count == 0)
//                return EnumError.ERR_OK;

//            long dataEnd = off + count;
//            if (sf.FileSize < dataEnd)
//                sf.FileSize = dataEnd;

//            ulong blockSize = ci.BlockSize;
//            uint block = (uint)((ulong)off / blockSize);

//            while (count > 0)
//            {
//                if (block >= ci.MapSize)
//                {
//                    // handle error for file too large
//                    return sf.F.LastError = EnumError.ERR_WRITE_FAILED;
//                }

//                int beg = (int)((ulong)off - block * blockSize);
//                int size = (int)(blockSize - (uint)beg);
//                if (size > count)
//                    size = count;

//                if (block >= ci.NeededBlocks)
//                {
//                    // append a new block
//                    ci.NeededBlocks = block + 1;
//                    uint destBlock = ci.UsedBlocks++;
//                    ci.Map[block] = (ushort)destBlock;
//                    long destOff = (long)(destBlock * (uint)blockSize + CISOConstants.CISO_HEAD_SIZE + beg);
//                    EnumError err = WriteAtF(sf.F, destOff, buf, size);
//                    if (err != EnumError.ERR_OK)
//                        return err;
//                }
//                else if (ci.Map[block] != CISOConstants.CISO_UNUSED_BLOCK)
//                {
//                    // modify an already written block
//                    long destOff = (long)(ci.Map[block] * (uint)blockSize + CISOConstants.CISO_HEAD_SIZE + beg);
//                    EnumError err = WriteAtF(sf.F, destOff, buf, size);
//                    if (err != EnumError.ERR_OK)
//                        return err;
//                }
//                else
//                {
//                    // handle error for writing to a skipped block
//                    return sf.F.LastError = EnumError.ERR_WRITE_FAILED;
//                }

//                off += size;
//                buf = buf.Skip(size).ToArray();
//                count -= size;
//                block++;
//            }

//            return EnumError.ERR_OK;
//        }

//        public static EnumError WriteSparseCISO(SuperFile sf, long off, byte[] buf, int count)
//        {
//            return SparseHelper(sf, off, buf, count, WriteCISO, CISOConstants.CISO_WR_MIN_HOLE_SIZE);
//        }

//        public static EnumError WriteZeroCISO(SuperFile sf, long off, int size)
//        {
//            byte[] zeroBuf = new byte[4096];
//            while (size > 0)
//            {
//                int size1 = size < zeroBuf.Length ? size : zeroBuf.Length;
//                EnumError err = WriteCISO(sf, off, zeroBuf, size1);
//                if (err != EnumError.ERR_OK)
//                    return err;
//                off += size1;
//                size -= size1;
//            }

//            return EnumError.ERR_OK;
//        }
//    }
//}