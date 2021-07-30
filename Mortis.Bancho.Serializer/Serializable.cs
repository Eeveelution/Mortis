using System;
using System.IO;
using System.Linq;
using System.Reflection;
using EeveeTools.Helpers;

namespace Mortis.Bancho.Serializer {
    public abstract class Serializable {
        public Serializable() {}

        public virtual void ReadFromStream(Stream readStream, bool resetSeek = true) {
            IOrderedEnumerable<FieldInfo> properties =
                this.GetType()
                    .GetFields()
                    //Where the `BanchoSerialize` Attribute exists
                    .Where(property => Attribute.IsDefined(property, typeof(BanchoSerialize)))
                    //Order by Decleration Order, this is to ensure that All objects from top to bottom get serialized, instead of being in random order
                    .OrderBy(property => ((BanchoSerialize)
                                 property.GetCustomAttributes(typeof(BanchoSerialize), false)
                                         .Single())
                                         .Order
                    );

            if(resetSeek)
                readStream.Seek(0, SeekOrigin.Begin);
            using BanchoReader reader = new(readStream);

            foreach (FieldInfo property in properties) {
                //For Arrays we require a little bit more code to handle multiple reads
                if (property.FieldType.IsArray) {
                    string baseType = property.FieldType.Name[..^2];

                    switch (baseType) {
                        case "String": {
                            string[] array = (string[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadString();

                            property.SetValue(this, array);

                            break;
                        }

                    }
                }
            }
        }
    }
}
