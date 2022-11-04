﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NominatimAPI.Address;
using NominatimAPI.Models;
using NominatimAPI.Web;
using NUnit.Framework;

namespace NominatimAPI.Tests
{
    public class AddressLookupTests {
        private IServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddNoninatimServices();
            serviceCollection.AddHttpClient();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        [Test]
        public async Task TestSuccessfulAddressLookup() {
            var addressSearcher = _serviceProvider.GetService<INominatimWebInterface>();
            
            var r = await addressSearcher.Lookup(new AddressSearchRequest {
                OSMIDs = new List<string>(new []{ "R146656", "W104393803", "N240109189" }),
                BreakdownAddressElements = true,
                ShowAlternativeNames = true,
                ShowExtraTags = true
            });

            Assert.IsTrue(r.Length > 0);
        }
    }
}