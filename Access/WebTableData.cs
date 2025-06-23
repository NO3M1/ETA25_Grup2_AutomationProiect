using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium.BiDi.Modules.Script;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Grup2_AutomationProject.NET.Access;
public partial class WebTableData
{
    private XElement dataNode;

    public WebTableData(int dataSetNumber)
    {
        LoadData(dataSetNumber);
        FirstName = GetValue("FirstName");
        LastName = GetValue("LastName");
        UserEmail = GetValue("UserEmail");
        Age = GetValue("Age");
        Salary = GetValue("Salary");
        Department = GetValue("Department");


    }


    private void LoadData(int dataSetNumber)
    {
        //paths-ul fisierului xml
        string path = @"C:\Users\nszoke\Source\Repos\AutomationProject\Resources\WebTableData.xml";

        //incacracm fisierul
        XDocument document = XDocument.Load(path);

        string nodeName = $"dataSet_{dataSetNumber}";
        dataNode = document.Root.Element(nodeName);

        if (dataNode == null )
        {
            throw new Exception($"Data set {dataSetNumber} not found in the XML file");

        }
    }

    //se ia valoare din dataSet
    private string GetValue(string nodeName)
    {
        return dataNode.Element(nodeName)?.Value ?? throw new Exception($"{nodeName} not found");
    }


}
