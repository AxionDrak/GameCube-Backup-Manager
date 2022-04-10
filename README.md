# GameCube Backup Manager
*The program has just entered the Pre-Release stage, and if everything is in order, it should be launched by the end of April/2022 (if an apocalypse doesn't happen!).*

**GCBM (GameCube Backup Manager)** is a program for working with FAT32 *(and NTFS)* drives to convert ISO files for use in Nintendont.

**Project base definitions:**

- Microsoft Visual Studio 2019
- Microsoft C# 7.3 programming language
- .NET Framework 4.7.2

**v2.1.0.0 - Release (end of April/2022)**

+ Added Scrub support *(GCReEx and DiscEx)*.
+ Added WiiTDB support.
+ Added support for automatic update system.
+ Added Proxy support.
+ Added support for Plugins system *(Experimental)*.
+ Added support for transferring covers to devices.
  + Adjustments to the program layout.
  + Improvements to the registry system.
+ Fixed crash in file transfer system *(1:1)*.

**v2.0.0.0 - Initial Release (Internal tests with selected people)**

+ Added support for automatic creation of 'games' folder *(if it doesn't exist)*.
+ Added support for ISO and GCM files.
+ Added support for transferring any ISO/GCM readable format to FAT32 or NTFS devices.
+ Added support for transferring game files with the correct nomenclature *(Game Name+ID or ID only)*.
+ Added support for deleting game files.
+ Added support for displaying game information *(region, publisher, genre, etc)*.
+ Added support for downloading game covers *(Disc, 2D, 3D, FullHQ)*.
+ Added support for individual cover download *(for selected game)*.
+ Added global cover download support *(for all listed games!)*.
+ Added support for downloading titles.txt *(GameTDB)*.
+ Added support for downloading wiitdb.xml *(GameTDB)*.
+ Added support for displaying ESRB ratings.
+ Added support for MD5 Hash calculation.
+ Added SHA-1 Hash calculation support.
+ Added support for improved GameCube ISO detection system *(75% accuracy)*.
+ Added XCopy system support *(1:1 copies of files - DEFAULT)*.
  + More polished, pleasant and less polluted interface *(UI)*.
