using CSAc4yClass.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSPersistentGeneratorLib
{
    public class EntityGenerate
    {
        //Date 2019 11 09 16:20

        #region values
        #endregion

        public static void entityGenerateMethods(string[] files, string package, string outputPath, string templatesFolder)
        {

            if (!Directory.Exists(outputPath + "PersistentMethods"))
                Directory.CreateDirectory(outputPath + "PersistentMethods");

            List<Ac4yClass> list = new List<Ac4yClass>();
            string[] files2 = files;

            foreach (var _file in files2)
            {
                string _filename = Path.GetFileNameWithoutExtension(_file);


                if (_filename.EndsWith("Persistent"))
                {
                    list.Add(DeserialiseMethod.deser(_file));
                }
            }


            Generator.contextGenerate("Template", outputPath, list, package, templatesFolder);


            for (var x = 0; x < list.Count; x++)
            {

                Generator.generateEntityMethods("TemplateEntityMethodsShort", package, list[x], outputPath, templatesFolder);
            }
        }
    }
}