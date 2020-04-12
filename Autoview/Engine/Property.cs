using Autoview.Elements;
using Autoview.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Autoview.Engine
{
    public class Property
    {
        public Property(string propertyValue, AElement element, PropertyInfo propertyInfo)
        {
            PropertyName = element.Name;

            PropertyValue = propertyValue;

            Element = element;

            PropertyInfo = propertyInfo;
        }

        public string PropertyName { get; set; }

        public string PropertyValue { get; set; }

        public AElement Element { get; set; }

        public PropertyInfo PropertyInfo { get; set; }

        public ModelErrorCollection ErrorCollection { get; set; } = null;

        public List<ErrorElement> ErrorElements { get; set; } = null;

        public static List<Property> InitPropertiesOfDto(Mainboard mainboard, ModelStateDictionary modelstate)
        {
            var tempList = new List<Property>();

            mainboard.Elements.ForEach(action: element => CheckPropertyAndAddToTempList(listOfProperties: ref tempList, mainboard.AutoviewDto, element, modelstate));

            return tempList;
        }

        public static void CheckPropertyAndAddToTempList(ref List<Property> listOfProperties, IAutoviewDto autoviewDto, AElement element, ModelStateDictionary modelstate)
        {
            try
            {
                listOfProperties.Add(item: InitProperty(autoviewDto, element, modelstate));
            }
            catch { }
        }

        public static Property InitProperty(IAutoviewDto autoviewDto, AElement element, ModelStateDictionary modelstate)
        {
            PropertyInfo getPropertyInfo = GetPropertyInfoOfDtoByName(autoviewDto, propertyName: element.Name);

            string getPropertyValue = Extensions.GetPropertyValue(autoviewDto, propertyInfo: getPropertyInfo);

            var newProperty = new Property(propertyValue: getPropertyValue, element, propertyInfo: getPropertyInfo);

            InitPropertyErrors(property: ref newProperty, modelstate);

            newProperty.Element = newProperty.Element.InitialElement(property: newProperty);

            return newProperty;
        }

        public static PropertyInfo GetPropertyInfoOfDtoByName(IAutoviewDto autoviewDto, string propertyName)
        {
            var getPropertyInfoFromDto = Extensions.GetPropertyInfoByName(autoviewDto, propertyName);

            if (getPropertyInfoFromDto is null) throw new Exception("property info not found");

            return getPropertyInfoFromDto;
        }

        public static void InitPropertyErrors(ref Property property, ModelStateDictionary modelstate)
        {
            property.ErrorCollection = Validation.Initial.InitErrorCollection(modelstate, propertyName: property.PropertyName);

            property.ErrorElements = Validation.Initial.InitPropertyErrorElements(property.ErrorCollection);
        }
    }
}