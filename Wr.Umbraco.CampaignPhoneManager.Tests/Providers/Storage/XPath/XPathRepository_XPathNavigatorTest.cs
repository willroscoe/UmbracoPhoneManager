﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Wr.Umbraco.CampaignPhoneManager.Models;

namespace Wr.Umbraco.CampaignPhoneManager.Tests.Providers.Storage.XPath
{
    [TestClass]
    public class XPathRepository_XPathNavigatorTest
    {
        [TestMethod]
        public void XPathRepository_GetXPathNavigator_CheckDefaultSettings_WithAllProperties_ReturnValid()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = "0800 000 0001", DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 32 };
            dataModel.CampaignDetail = new List<CampaignDetail>() { new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" } };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetDefaultSettings();

            // Assert
            Assert.IsTrue(act.DefaultPhoneNumber == dataModel.DefaultPhoneNumber);
            Assert.IsTrue(act.DefaultCampaignQueryStringKey == dataModel.DefaultCampaignQueryStringKey);
            Assert.IsTrue(act.DefaultPersistDurationInDays == dataModel.DefaultPersistDurationInDays);
        }

        [TestMethod]
        public void XPathRepository_GetXPathNavigator_CheckDefaultSettings_WithDefaultValueForMissingPropertyDefaultPersistDurationInDays_ReturnValid()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = "0800 000 0001", DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 0 };
            dataModel.CampaignDetail = new List<CampaignDetail>() { new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" } };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetDefaultSettings();

            // Assert
            Assert.IsTrue(act.DefaultPhoneNumber == dataModel.DefaultPhoneNumber);
            Assert.IsTrue(act.DefaultCampaignQueryStringKey == dataModel.DefaultCampaignQueryStringKey);
            Assert.IsTrue(act.DefaultPersistDurationInDays == 30);
        }

        [TestMethod]
        public void XPathRepository_GetXPathNavigator_CheckDefaultSettings_WithEmptyDefaultPhoneNumber_ReturnValid()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = "", DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 0 };
            dataModel.CampaignDetail = new List<CampaignDetail>() { new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" } };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetDefaultSettings();

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(act.DefaultPhoneNumber));
        }

        [TestMethod]
        public void XPathRepository_GetXPathNavigator_CheckDefaultSettings_WithMissingDefaultPhoneNumber_ReturnValid()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = null, DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 0 };
            dataModel.CampaignDetail = new List<CampaignDetail>() { new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" } };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetDefaultSettings();

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(act.DefaultPhoneNumber));
        }

        [TestMethod]
        public void XPathRepository_GetXPathNavigator_GetCampaignDetailById_WithMatchingRecord_ReturnValid()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = null, DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 0 };
            dataModel.CampaignDetail = new List<CampaignDetail>()
                {
                    new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" },
                    new CampaignDetail() { Id = "1202", TelephoneNumber = "0800 000 4567", CampaignCode = "testcode2" }
                };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetCampaignDetailById("1202");

            // Assert
            Assert.AreEqual("1202", act.Id);
        }

        [TestMethod]
        public void XPathRepository_GetXPathNavigator_GetCampaignDetailById_WithNoMatchingRecord_ReturnNull()
        {
            // Arrange
            var dataModel = new CampaignPhoneManagerModel() { DefaultPhoneNumber = null, DefaultCampaignQueryStringKey = "fsource", DefaultPersistDurationInDays = 0 };
            dataModel.CampaignDetail = new List<CampaignDetail>()
                {
                    new CampaignDetail() { Id = "1201", TelephoneNumber = "0800 123 4567", CampaignCode = "testcode" },
                    new CampaignDetail() { Id = "1202", TelephoneNumber = "0800 000 4567", CampaignCode = "testcode2" }
                };

            var testPhoneManagerData = dataModel.ToXmlString();

            var method = TestRepository.GetRepository(testPhoneManagerData);

            // Act
            var act = method.GetCampaignDetailById("1203");

            // Assert
            Assert.IsNull(act.Id);
        }
    }
}