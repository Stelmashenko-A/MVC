//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace MVC.Repository
//{
//    public class FileRepository : IRepository
//    {
//        private const string Path = @"C:\Users\Андрей\Documents\MVC\";
//        private const string NameBase = @"names.txt";
//        private const string FileFormat = ".txt";
//        private readonly Dictionary<string, string> _dataBase = new Dictionary<string, string>();

//        public FileRepository()
//        {
//            var file = new StreamReader(Path + NameBase);
//            string line;
//            while ((line = file.ReadLine()) != null)
//            {
//                var data = new StreamReader(Path + line + FileFormat);
//                _dataBase.Add(line, data.ReadToEnd());
//                data.Close();
//            }

//            file.Close();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<string> Get()
//        {
//            return _dataBase.Keys;
//        }

//        public string Get(string id)
//        {
//            return _dataBase.ContainsKey(id) ? _dataBase[id] : string.Empty;
//        }

//        public void Delete(string id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Save()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}