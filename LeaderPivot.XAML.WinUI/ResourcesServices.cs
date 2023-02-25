using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderAnalytics.LeaderPivot.XAML.WinUI;
public class ResourcesServices
{

    /// <summary> 
    /// Identifies the Resources attachted property. This enables animation, styling, binding, etc...
    /// </summary>
    public static readonly DependencyProperty ResourcesProperty =
        DependencyProperty.RegisterAttached("Resources",
               typeof(ResourceDictionary),
               typeof(ResourcesServices),
               new PropertyMetadata(default(ResourceDictionary), OnResourcesChanged));

    /// <summary>
    /// Resources changed handler. 
    /// </summary>
    /// <param name="d">FrameworkElement that changed its Resources attached property.</param>
    /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
    private static void OnResourcesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FrameworkElement source)
        {
            var value = (ResourceDictionary)e.NewValue;
            ResourceDictionaryCloner.Clone(value, source.Resources);
        }
    }

    /// <summary>
    /// Gets the value of the Resources attached property from the specified FrameworkElement.
    /// </summary>
    public static ResourceDictionary GetResources(DependencyObject obj)
    {
        return (ResourceDictionary)obj.GetValue(ResourcesProperty);
    }


    /// <summary>
    /// Sets the value of the Resources attached property to the specified FrameworkElement.
    /// </summary>
    /// <param name="obj">The object on which to set the Resources attached property.</param>
    /// <param name="value">The property value to set.</param>
    public static void SetResources(DependencyObject obj, ResourceDictionary value)
    {
        obj.SetValue(ResourcesProperty, value);
    }
}

internal static class ResourceDictionaryCloner
{

    internal static ResourceDictionary Clone(ResourceDictionary resource, ResourceDictionary destination)
    {
        if (resource == null) return null;

        if (resource.Source != null)
        {
            destination.Source = resource.Source;
        }
        else
        {
            // Clone theme dictionaries
            if (resource.ThemeDictionaries != null)
            {
                foreach (var theme in resource.ThemeDictionaries)
                {
                    if (theme.Value is ResourceDictionary themedResource)
                    {
                        var themeDictionary = new ResourceDictionary();
                        Clone(themedResource, themeDictionary);
                        destination.ThemeDictionaries[theme.Key] = themeDictionary;
                    }
                    else
                    {
                        destination.ThemeDictionaries[theme.Key] = theme.Value;
                    }
                }
            }

            // Clone merged dictionaries
            if (resource.MergedDictionaries != null)
            {
                foreach (var mergedResource in resource.MergedDictionaries)
                {
                    var themeDictionary = new ResourceDictionary();
                    Clone(mergedResource, themeDictionary);
                    destination.MergedDictionaries.Add(themeDictionary);
                }
            }

            // Clone all contents
            foreach (var item in resource)
            {
                destination[item.Key] = item.Value;
            }
        }

        return destination;
    }
}