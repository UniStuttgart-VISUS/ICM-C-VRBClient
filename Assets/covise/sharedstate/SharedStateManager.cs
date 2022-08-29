using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using covise.attributes;
using covise.reflections;
using UnityEngine;

namespace covise.sharedstate
{
    public class SharedStateManager
    {
        private static SharedStateManager INSTANCE = null;
        
        public Dictionary<Type, List<object>> sharedInstanceObjects = null;

        public Dictionary<Type, int> sharedInstanceMaxUUIDs = null;
        
        private SharedStateManager()
        {
            //SharedPointerFactory.registerDefault();
            sharedInstanceObjects = new Dictionary<Type, List<object>>();
        }

        public static SharedStateManager getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SharedStateManager();
            }

            return INSTANCE;
        }

        public bool registerSharedInstance<T>(T instance) where T: Component
        {

            SharedClassAttribute classAttrib = (SharedClassAttribute)AttributeTools.getFirstAttributeOfType(instance.GetType(), typeof(SharedClassAttribute));

            if (classAttrib == null)
            {
                classAttrib = new SharedClassAttribute(); // Use Default if no Attribute is present
            }

            int instanceID = computeInstanceID(classAttrib);

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

        private int computeInstanceID(SharedClassAttribute classAttrib)
        {
            switch (classAttrib.idType)
            {
                case InstanceIDType.AUTO:
                    //TODO: Auto-Generate Instance ID
                    return 0;
                case InstanceIDType.MANUAL:
                    //TODO: Fetch manual Instance ID
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void registerSharedVariable<T>(T instance, int instanceID, FieldInfo field, SharedClassAttribute classAttrib, SharedVariableAttribute attrib) where T: Component
        {
            SharedVariableInterface shared = SharedPointerFactory.createPointer(instance, instanceID, field);

            Debug.Log("Created Pointer of Type:" + shared.GetType() + " for class " + instance.GetType() + ".");
            
            // TODO: Setup Observer
            // TODO: Store Pointers & push on Create Session or Pull on join session
            // TODO: Implement generic serialisation for all unsupported types (i.e. Object) ? see IFormatter, use seems to be discouraged ? --> Is custom object serialisation required ?
        }
    }
}