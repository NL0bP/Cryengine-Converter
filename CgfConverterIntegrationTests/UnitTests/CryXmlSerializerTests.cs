﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CgfConverter.Materials;

namespace CgfConverterTests.IntegrationTests;

[TestClass]
public class CryXmlSerializerTests
{
    string userHome;

    [TestInitialize]
    public void Initialize()
    {
        userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }


    [TestMethod]
    public void ReadFile_SimpleMaterialXmlFile_NoSubmats()
    {
        var filename = @"..\..\..\TestData\SimpleMat.xml";

        var material = MaterialUtilities.FromFile(filename);

        Assert.IsNull(material.SubMaterials);
        Assert.AreEqual(4, material.Textures.Length);

    }

    [TestMethod]
    public void ReadFile_MutliMaterialXmlFile_HasSubmats()
    {
        var filename = @"..\..\..\TestData\MultipleMats.xml";

        var material = MaterialUtilities.FromFile(filename);

        Assert.IsNotNull(material.SubMaterials);
        Assert.IsNull(material.Textures);

        Assert.AreEqual(5, material.SubMaterials.Length);
    }

    [TestMethod]
    public void ReadFile_StarCitizenBinaryMatFile()
    {
        var filename = @"..\..\..\TestData\SC_mat.mtl";

        var material = MaterialUtilities.FromFile(filename);
        Assert.IsNotNull(material.SubMaterials);
        Assert.AreEqual(2, material.SubMaterials.Length);
    }
}