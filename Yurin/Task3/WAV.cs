using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Wav
    {
        public int _nOriginalLen;

        public int _nHz;

        public int _nBitsPerSample;

        public int _nBytesPerSec;

        public int _nChannels;

        public enum Domain

        {

            TimeDomain = 1,

            FreqDomain = 2

        };



        Domain currentDomain = Domain.TimeDomain;

        int _np2;

        public double[] _aSamples;

        public double[] _aImaginary;


        public void ReadWav(String fileName)
        {
            currentDomain = Domain.TimeDomain;

            using (var file = File.Open(fileName, FileMode.Open, FileAccess.Read))

            {

                if (file.ReadStr(4) != "RIFF")

                {

                    throw new InvalidDataException("не wav");

                }

                var nFileLen = file.ReadInt() + 8;

                if (file.ReadStr(8) != "WAVEfmt ")

                {

                    throw new InvalidDataException("не wav");

                }

                var nSubchunk = file.ReadInt();



                var AudioFormat = file.ReadInt16();

                if (AudioFormat != 1)

                {

                    throw new InvalidDataException("Только PCM поддерживается");

                }

                _nChannels = file.ReadInt16();

                _nHz = file.ReadInt();

                _nBytesPerSec = file.ReadInt();

                var nBlkAlign = file.ReadInt16();

                _nBitsPerSample = file.ReadInt16();

                var ExtraPadding = file.ReadStr(nSubchunk - 16);

                bool findSten = false;

                while (file.Position < file.Length)

                {

                    var cSection = file.ReadStr(4);
                    //Console.WriteLine(cSection);

                    switch (cSection)

                    {

                        case "fact":

                            var nFactchunk = file.ReadInt();

                            var nRealSize = file.ReadInt(); //uncompressed # of samples

                            break;

                        case "data":

                            var nBytesData = file.ReadInt();

                            var nSamples = (int)(nBytesData / (_nBitsPerSample / 8));

                            _aSamples = new double[nSamples];

                            for (int i = 0; i < nSamples; i++)

                            {

                                switch (_nBitsPerSample)

                                {

                                    case 8:

                                        _aSamples[i] = file.ReadByte() - 128;

                                        break;

                                    case 16:

                                        _aSamples[i] = file.ReadInt16();

                                        break;

                                }

                            }

                            break;

                        case "IC0P":
                            var length = file.ReadInt();
                            var arr = new byte[length - 1];
                            file.Read(arr, 0, length - 1);
                            FileStream fileStream = File.Create("info.txt");
                            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                            binaryWriter.Write(arr);
                            findSten = true;
                            binaryWriter.Flush();
                            binaryWriter.Close();
                            

                            break;

                        default:
                            break;

                    }

                }
                if (!findSten)
                    Console.WriteLine("Информация не найдена");

            }
        }

        public void AppendInfo(string pathWav, string pathBin)
        {
            var bytes = File.ReadAllBytes(pathBin);
            currentDomain = Domain.TimeDomain;
            var fileWithInfo = File.OpenWrite("_" + pathWav);
            var file = File.Open(pathWav, FileMode.Open, FileAccess.Read);
            file.CopyTo(fileWithInfo);
            file.Position = 0;
                
            if (file.ReadStr(4) != "RIFF")
            {
               throw new InvalidDataException("не wav");
            }

            fileWithInfo.Position = file.Position;
            var nFileLen = file.ReadInt() + 8;
            fileWithInfo.Write(nFileLen-8+pathBin.Length);

            if (file.ReadStr(8) != "WAVEfmt ")
            {
                throw new InvalidDataException("не wav");
            }
            var nSubchunk = file.ReadInt();
            var AudioFormat = file.ReadInt16();
            if (AudioFormat != 1)
            {
                throw new InvalidDataException("Только PCM поддерживается");
            }

            _nChannels = file.ReadInt16();
            _nHz = file.ReadInt();
            _nBytesPerSec = file.ReadInt();
            var nBlkAlign = file.ReadInt16();
            _nBitsPerSample = file.ReadInt16();
            var ExtraPadding = file.ReadStr(nSubchunk - 16);

                while (file.Position < file.Length)

                {

                    var cSection = file.ReadStr(4);

                    switch (cSection)

                    {

                        case "fact":

                            var nFactchunk = file.ReadInt();

                            var nRealSize = file.ReadInt();

                            break;

                        case "data":

                            var nBytesData = file.ReadInt();

                            var nSamples = (int)(nBytesData / (_nBitsPerSample / 8));

                            _aSamples = new double[nSamples];

                            for (int i = 0; i < nSamples; i++)

                            {

                                switch (_nBitsPerSample)

                                {

                                    case 8:

                                        _aSamples[i] = file.ReadByte() - 128;

                                        break;

                                    case 16:

                                        _aSamples[i] = file.ReadInt16();

                                        break;

                                }

                            }

                            break;

                        case "LIST":
                            fileWithInfo.Position = file.Position;
                            var length = file.ReadInt();
                            fileWithInfo.Write(length+bytes.Length);
                            if (file.ReadStr(4) != "INFO")
                                throw new InvalidDataException("Не содержится chunk INFO");
                            fileWithInfo.Position = file.Position;
                            String copyEnd = file.ReadStr(nFileLen - (int)file.Position);
                            fileWithInfo.Write("IC0P");
                            fileWithInfo.Write(bytes.Length+1);
                            fileWithInfo.Write(bytes);
                            fileWithInfo.Write(copyEnd);

                            break;

                        default:
                            break;

                    }

                }
            fileWithInfo.Flush();
            fileWithInfo.Close();
        }
    }
}
