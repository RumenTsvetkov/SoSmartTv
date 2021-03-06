﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Collections.Immutable;
using FakeItEasy;
using Microsoft.Data.Entity;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SoSmartTv.VideoFilesProvider;
using SoSmartTv.VideoService.Dto;
using SoSmartTv.VideoService.Services;
using SoSmartTv.VideoService.Store;
using Xunit;
using Assert = Xunit.Assert;

namespace SoSmartTv.VideoService.Tests.Store
{
	public class LocalDatabaseStoreTests
	{
		private readonly IVideoItemsStoreReader _sut;
		private readonly List<VideoItem> _data;

		public LocalDatabaseStoreTests()
		{
			_data = new List<VideoItem>
			{
				new VideoItem() {Title = "A", Id = 1},
				new VideoItem() {Title = "D", Id = 2},
				new VideoItem() {Title = "F", Id = 3},
			};

			var context = SetupDbContextWithDbSet(dbContext => dbContext.VideoItems.AddRange(_data));

			_sut = new LocalDatabaseStore(context);
		}

		private List<VideoFileProperty> GetInputFiles()
		{
			return new List<VideoFileProperty>()
			{
				new VideoFileProperty("path") {Title = "A"},
				new VideoFileProperty("path") {Title = "B"},
				new VideoFileProperty("path") {Title = "C"},
				new VideoFileProperty("path") {Title = "D"},
				new VideoFileProperty("path") {Title = "E"},
				new VideoFileProperty("path") {Title = "F"},
				new VideoFileProperty("path") {Title = "G"}
			};
		}

		private VideoDbContext SetupDbContextWithDbSet(Action<VideoDbContext> setupDbSet)
		{
			var optionsBuilder = new DbContextOptionsBuilder<VideoDbContext>();
			optionsBuilder.UseInMemoryDatabase();

			var context = new VideoDbContext(optionsBuilder.Options);
			setupDbSet(context);
			context.SaveChanges();
			return context;
		}

		[Fact]
		public void GetVideoItems_returns_correct_items()
		{
			var titles = GetInputFiles().Select(x => x.Title).ToList();
			var results = _sut.GetVideoItems(titles).Wait();
			
			Assert.Equal(results.Count, _data.Count);
			CollectionAssert.AreEqual(results.Select(x => x.Id).ToList(), _data.Select(x => x.Id).ToList());
		}
	}
}