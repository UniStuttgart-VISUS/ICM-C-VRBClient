using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using covise.attributes;
using covise.reflections;
using covise.sharedstate.connectors;
using UnityEngine;

namespace covise.sharedstate
{
    public class SharedStateManager
    {
        private static SharedStateManager INSTANCE = null;
        public static IConnector CONNECTOR = null;
        
        protected Dictionary<string, Dictionary<string, Dictionary<string, SharedVariableInterface>>> sharedVars = null;
        protected Dictionary<object, string> idLUT = null;

        protected Dictionary<Type, int> sharedInstanceMaxUUIDs = null;
        
        private SharedStateManager()
        {
            //SharedPointerFactory.registerDefault();
            sharedInstanceMaxUUIDs = new Dictionary<Type, int>();
            idLUT = new Dictionary<object, string>();
            sharedVars = new Dictionary<string, Dictionary<string, Dictionary<string, SharedVariableInterface>>>();
        }

        public static SharedStateManager getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SharedStateManager();
            }

            return INSTANCE;
        }

        #region  Get & Put Shared variables

        public SharedVariableInterface getSharedVariable(string type, string instance, string field)
        {
            if (!sharedVars.ContainsKey(type))
            {
                return null;
            }
            
            if (!sharedVars[type].ContainsKey(instance))
            {
                return null;
            }
            
            if (!sharedVars[type][instance].ContainsKey(field))
            {
                return null;
            }

            return sharedVars[type][instance][field];
        }
        
        public SharedVariableInterface getSharedVariable<T>(T instance, string field)
        {
            string type = instance.GetType().ToString();
            string id = "";
            
            if (idLUT.ContainsKey(instance))
            {
                id = idLUT[instance];
            }

            return getSharedVariable(type, id, field);
        }

        public SharedVariableInterface getSharedVariable<T>(T instance, string id, string field)
        {
            string type = instance.GetType().ToString();
            return getSharedVariable(type, id, field);
        }
        
        public SharedVariableInterface getSharedVariable (Type objectType, string instance, string field)
        {
            string type = objectType.ToString();

            return getSharedVariable(type, instance, field);
        }
        
        public SharedVariableInterface getSharedVariable<T>(T instance, FieldInfo field)
        {
            string type = instance.GetType().ToString();
            string id = "";
            
            if (idLUT.ContainsKey(instance))
            {
                id = idLUT[instance];
            }

            return getSharedVariable(type, id, field.Name);
        }

        public SharedVariableInterface getSharedVariable<T>(T instance, string id, FieldInfo field)
        {
            string type = instance.GetType().ToString();
            return getSharedVariable(type, id, field.Name);
        }
        
        public SharedVariableInterface getSharedVariable (Type objectType, string instance, FieldInfo field)
        {
            string type = objectType.ToString();

            return getSharedVariable(type, instance, field.Name);
        }
        
        public void putSharedVariable(string type, string instance, string field, SharedVariableInterface var)
        {
            if (!sharedVars.ContainsKey(type))
            {
                sharedVars.Add(type, new Dictionary<string, Dictionary<string, SharedVariableInterface>>());
            }
            
            if (!sharedVars[type].ContainsKey(instance))
            {
                sharedVars[type].Add(instance, new Dictionary<string, SharedVariableInterface>());
            }
            
            sharedVars[type][instance].Add(field, var);
        }

        public void putSharedVariable<T>(T instance, string field, SharedVariableInterface var)
        {
            string type = instance.GetType().ToString();
            string id = "";
            
            if (idLUT.ContainsKey(instance))
            {
                id = idLUT[instance];
            }

            putSharedVariable(type, id, field, var);
        }

        public void putSharedVariable<T>(T instance, FieldInfo field, SharedVariableInterface var)
        {
            string type = instance.GetType().ToString();
            string id = "";
            
            if (idLUT.ContainsKey(instance))
            {
                id = idLUT[instance];
            }

            putSharedVariable(type, id, field.Name, var);
        }
        
        public void putSharedVariable<T>(T instance, string id, string field, SharedVariableInterface var)
        {
            string type = instance.GetType().ToString();
            putSharedVariable(type, id, field, var);
        }
        
        public void putSharedVariable<T>(T instance, string id, FieldInfo field, SharedVariableInterface var)
        {
            string type = instance.GetType().ToString();
            putSharedVariable(type, id, field.Name, var);
        }
        
        public void putSharedVariable (Type objectType, string instance, string field, SharedVariableInterface var)
        {
            string type = objectType.ToString();

            putSharedVariable(type, instance, field, var);
        }

        #endregion

        #region Lists

        public string[] listRegisteredTypes()
        {
            return sharedVars.Keys.ToArray();
        }

        public string[] listRegisteredInstances(string type)
        {
            return sharedVars[type].Keys.ToArray();
        }
        
        public string[] listRegisteredVariables(string type, string instance)
        {
            return sharedVars[type][instance].Keys.ToArray();
        }
        
        #endregion

        #region debugging

        public string getSharedRegistryContents()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string type in listRegisteredTypes())
            {
                sb.Append(type);
                sb.Append(":\n");

                foreach (string instance in listRegisteredInstances(type))
                {
                    sb.Append("\t");
                    sb.Append(instance);
                    sb.Append(":\n");

                    foreach (string var in listRegisteredVariables(type, instance))
                    {
                        sb.Append("\t");
                        sb.Append("\t");
                        sb.Append(var);
                        sb.Append("\n");
                    }
                }
            }

            return sb.ToString();
        }

        #endregion
        
        #region Instance Registration

        public bool registerSharedInstance<T>(T instance) where T: Component
        {

            SharedClassAttribute classAttrib = (SharedClassAttribute)AttributeTools.getFirstAttributeOfType(instance.GetType(), typeof(SharedClassAttribute));

            if (classAttrib == null)
            {
                classAttrib = new SharedClassAttribute(); // Use Default if no Attribute is present
            }

            string instanceID = computeInstanceID(instance, classAttrib);

            FieldInfo[] fields = AttributeTools.getFields(instance.GetType());

            for (int i = 0; i < fields.Length; i++)
            {
                SharedVariableAttribute attrib = AttributeTools.getSharedVariable(fields[i]);
                if (attrib != null)
                {
                    registerSharedVariable(instance, instanceID, fields[i], classAttrib, attrib);
                }
            }

            return true;
        }

        private string computeInstanceID<T>(T instance, SharedClassAttribute classAttrib)
        {
            StringBuilder sb = new StringBuilder();
            switch (classAttrib.idType)
            {
                case InstanceIDType.AUTO:
                    if (!sharedInstanceMaxUUIDs.ContainsKey(instance.GetType()))
                    {
                        sharedInstanceMaxUUIDs.Add(instance.GetType(), 0);
                    }

                    sb.Append("A");
                    sb.Append(sharedInstanceMaxUUIDs[instance.GetType()]++);
                    break;
                case InstanceIDType.MANUAL:
                    FieldInfo field = AttributeTools.getField(instance.GetType(), classAttrib.instanceIDName);
                    if (field == null)
                    {
                        throw new ArgumentException("Unable to find explicit instance id field. Expected field '" 
                                       + classAttrib.instanceIDName + "' in type '" + instance.GetType() + "' Fallback to automatic instance id.");
/*                        sb.Append("A");
                        if (!sharedInstanceMaxUUIDs.ContainsKey(instance.GetType()))
                        {
                            sharedInstanceMaxUUIDs.Add(instance.GetType(), 0);
                        }
                        sb.Append(sharedInstanceMaxUUIDs[instance.GetType()]++);
                       
                        break;*/
                    }
                    
                    sb.Append("M");
                    sb.Append(field.GetValue(instance));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            idLUT.Add(instance, sb.ToString());
            return sb.ToString();
        }

        private void registerSharedVariable<T>(T instance, string instanceID, FieldInfo field, SharedClassAttribute classAttrib, SharedVariableAttribute attrib) where T: Component
        {
            SharedVariableInterface shared = SharedPointerFactory.createPointer(instance, instanceID, field);
            putSharedVariable(instance, instanceID, field, shared);
            
            Debug.Log("Created Pointer of Type:" + shared.GetType() + " for class " + instance.GetType() + ".");
            
            // TODO: Implement generic serialisation for all unsupported types (i.e. Object) ? see IFormatter, use seems to be discouraged ? --> Is custom object serialisation required ?
        }

        #endregion

        #region Shared Variable Handling

        public void registerAllSharedVariables()
        {
            foreach (string typename in sharedVars.Keys)
            {
                foreach (string instanceID in sharedVars[typename].Keys)
                {
                    foreach (string variable in sharedVars[typename][instanceID].Keys)
                    {
                        CONNECTOR.registerVariable(sharedVars[typename][instanceID][variable]);
                    }
                }
            }
        }

        public void subscribeToAllSharedVariables()
        {
            foreach (string typename in sharedVars.Keys)
            {
                foreach (string instanceID in sharedVars[typename].Keys)
                {
                    foreach (string variable in sharedVars[typename][instanceID].Keys)
                    {
                        CONNECTOR.subscribeVariable(sharedVars[typename][instanceID][variable]);
                    }
                }
            }
        }

        public void pushAllSharedVariables()
        {
            foreach (string typename in sharedVars.Keys)
            {
                foreach (string instanceID in sharedVars[typename].Keys)
                {
                    foreach (string variable in sharedVars[typename][instanceID].Keys)
                    {
                        CONNECTOR.pushVariable(sharedVars[typename][instanceID][variable]);
                    }
                }
            }
        }
        
        #endregion
        
    }
}