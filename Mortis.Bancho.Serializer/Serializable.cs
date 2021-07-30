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
                        case "Byte": {
                            byte[] array = (byte[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadByte();

                            property.SetValue(this, array);

                            break;
                        }
                        case "Int32": {
                            int[] array = (int[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadInt32();

                            property.SetValue(this, array);

                            break;
                        }
                        case "Int16": {
                            short[] array = (short[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadInt16();

                            property.SetValue(this, array);

                            break;
                        }
                        case "Int64": {
                            long[] array = (long[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadInt64();

                            property.SetValue(this, array);

                            break;
                        }
                        case "UInt32": {
                            uint[] array = (uint[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadUInt32();

                            property.SetValue(this, array);

                            break;
                        }
                        case "UInt16": {
                            ushort[] array = (ushort[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadUInt16();

                            property.SetValue(this, array);

                            break;
                        }
                        case "UInt64": {
                            ulong[] array = (ulong[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadUInt64();

                            property.SetValue(this, array);

                            break;
                        }
                        case "Single": {
                            float[] array = (float[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadSingle();

                            property.SetValue(this, array);

                            break;
                        }
                        case "Double": {
                            double[] array = (double[])property.GetValue(this);

                            if (array == null)
                                throw new NullReferenceException("Initialize Serializable Array fields!!!!!!");

                            for (int i = 0; i != array.Length; i++)
                                array[i] = reader.ReadDouble();

                            property.SetValue(this, array);

                            break;
                        }
                    }
                }
            }
        }
    }
}
