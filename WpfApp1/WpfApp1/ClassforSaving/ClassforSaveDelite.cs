using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.NewFolder1;

namespace WpfApp1.ClassforSaving
{
    internal class ClassforSaveDelite
    {
        private readonly string Path;

        public ClassforSaveDelite(string path)
        {
            Path = path;
        }
        public BindingList<Todomod> LoadData() 
        
        {
            if (!File.Exists(Path))
            { File.CreateText(Path).Dispose();
                return new BindingList<Todomod>();
            }
            using (var reader = File.OpenText(Path))
            { string filetext = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Todomod>>(filetext);

            }
                    
                    
                    }
        
        public void SaveData(object tododatalist) 
        {
            using (StreamWriter writer = File.CreateText(Path))
            { string output = JsonConvert.SerializeObject(tododatalist);
                writer.Write(output);
            }
        
        }
    }

}
