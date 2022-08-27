using System;
using System.Collections.Generic;
using System.Reflection;
using covise.attributes;
using UnityEngine;

namespace covise.reflections
{
    public class AttributeTools
    {

        #region Shared Attributes

        /// <summary>
        ///  Checks if the SharedVariable Attribute is present on the property
        /// </summary>
        /// <param name="info">FieldInfo of the field to check</param>
        /// <returns>True if the SharedVariable, False otherwise</returns>
        public static bool isSharedVariable(FieldInfo info)
        {
            SharedVariableAttribute sharedVarAttribute = (SharedVariableAttribute) getFieldAttribute(info, typeof(SharedVariableAttribute));
            return (sharedVarAttribute != null);
        }
        
        /// <summary>
        ///  Checks if the SharedVariable Attribute is present on the property
        /// </summary>
        /// <param name="info">FieldInfo of the field to check</param>
        /// <returns>SharedVariableAttribute</returns>
        public static SharedVariableAttribute getSharedVariable(FieldInfo info)
        {
            SharedVariableAttribute sharedVarAttribute = (SharedVariableAttribute) getFieldAttribute(info, typeof(SharedVariableAttribute));
            return sharedVarAttribute;
        }

        /// <summary>
        ///  Checks if the SharedVClass Attribute is present on the property
        /// </summary>
        /// <param name="info">FieldInfo of the field to check</param>
        /// <returns>SharedClassAttribute</returns>
        public static SharedClassAttribute getSharedClass(FieldInfo info)
        {
            SharedClassAttribute sharedClassAttribute = (SharedClassAttribute) getFieldAttribute(info, typeof(SharedClassAttribute));
            return sharedClassAttribute;
        }
        
        #endregion
        
        #region FieldInfos

        /// <summary>
        /// Gets the attribute of the given type for the given property of the given Editor
        /// </summary>
        /// <param name="objectType">Type containing the property</param>
        /// <param name="propertyName">Name of the property whose value to get</param>
        /// <param name="attrbType">Type of Attribute to get</param>
        /// <returns></returns>
        public static Attribute getFieldAttribute(Type objectType, string propertyName, Type attrbType)
        {
            FieldInfo info = objectType.GetField(propertyName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            
            if (info == null)
            {
                FieldInfo[] availableProperties =
                    objectType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default);

                string names = "";
                foreach (FieldInfo pi in availableProperties)
                {
                    names += (pi.Name + ", ");
                }

                Debug.LogWarning("Field not Found: " + propertyName + ", Available: " + names);

                return null;
            }

            return getFieldAttribute(info, attrbType);
        }
        
        /// <summary>
        /// Gets the first available attribute of the given type for the given field, or null if no attribute is present
        /// </summary>
        /// <param name="info"></param>
        /// <param name="attrbType"></param>
        /// <returns></returns>
        public static Attribute getFieldAttribute(FieldInfo info, Type attrbType)
        {
            Attribute attrib = System.Attribute.GetCustomAttribute(info, attrbType);

            if (attrib == null)
            {
                Attribute[] availableAttributes = System.Attribute.GetCustomAttributes(info);

                string names = "";
                foreach (Attribute pi in availableAttributes)
                {
                    names += (pi.GetType() + ", ");
                }
            }
                
            return attrib;
        }

        /// <summary>
        /// Returns all available fields
        /// </summary>
        /// <param name="objectType">Type whose FieldInfos to get</param>
        /// <returns>All fields of the Type</returns>
        public static FieldInfo[] getFields(Type objectType)
        {
            return objectType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default);
        }

        #endregion
        
        #region General Tools

        /// <summary>
        /// Returns the first instance of the given attribute for the given type
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <param name="attributeType">AttributeType to check for</param>
        /// <returns>The first attribute from type of AttributeType, or null if not found</returns>
        public static Attribute getFirstAttributeOfType(Type type, Type attributeType)
        {
            Attribute[] attributes = getTypeAttributes(type);

            List<Attribute> results = new List<Attribute>();

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType() == attributeType)
                {
                    return attributes[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Returns all attributes of the given attribute type for the given type
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <param name="attributeType">AttributeType to check for</param>
        /// <returns>The first attribute from type of AttributeType, or null if not found</returns>
        public static Attribute[] getAttributesOfType(Type type, Type attributeType)
        {
            Attribute[] attributes = getTypeAttributes(type);

            List<Attribute> results = new List<Attribute>();

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType().IsSubclassOf(attributeType))
                {
                    results.Add(attributes[i]);
                }
            }

            return results.ToArray();
        }
        
        /// <summary>
        /// Returns all Attributes for the given type
        /// </summary>
        /// <param name="type">Type to get attributes from</param>
        /// <returns>All attributes of type</returns>
        public static Attribute[] getTypeAttributes(Type type)
        {
            return System.Attribute.GetCustomAttributes(type);
        }
        
        #endregion
    }
}