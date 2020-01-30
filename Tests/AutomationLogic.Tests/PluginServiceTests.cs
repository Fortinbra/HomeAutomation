﻿using AutoFixture;
using BecauseImClever.HomeAutomation.Abstractions;
using BecauseImClever.HomeAutomation.AutomationLogic.Services;
using BecauseImClever.HomeAutomation.AutomationModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AutomationLogic.Tests
{
    public class PluginServiceTests
    {
        private readonly Mock<IPluginRepository> _mockPluginRepository;
        private readonly Fixture _fixture;
        public PluginServiceTests()
        {
            _fixture = new Fixture();
            _mockPluginRepository = new Mock<IPluginRepository>();
        }
        [Fact]
        public void CreatePluginService()
        {
            var service = new PluginService(_mockPluginRepository.Object);
            Assert.NotNull(service);
        }
        [Fact]
        public void CreatePluginServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => { new PluginService(null); });
        }
        #region Create
        [Fact]
        public async Task CreatePluginAsyncReturnsPlugin()
        {
            var plugin = _fixture.Create<Plugin>();
            _mockPluginRepository.Setup(x => x.CreateAsync(It.IsAny<Plugin>())).ReturnsAsync(plugin);
            var service = new PluginService(_mockPluginRepository.Object);
            var result = await service.CreateAsync(new Plugin()).ConfigureAwait(false);
            Assert.NotNull(result);
            Assert.IsType<Plugin>(result);
        }
        #endregion
        #region Read
        [Fact]
        public async Task GetAllPlugins()
        {
            var plugins = _fixture.CreateMany<Plugin>(25);
            _mockPluginRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(plugins);
            var service = new PluginService(_mockPluginRepository.Object);
            var result = await service.GetAllAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<IEnumerable<Plugin>>(result);
        }
        #endregion

    }
}
