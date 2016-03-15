using System.Collections.Generic;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using SoSmartTv.TheMovieDatabaseApi.JsonItemConverters;

namespace SoSmartTv.TheMovieDatabaseApi.Dtos
{
	public class VideoDetailsInfo
	{
		public bool Adult { get; set; }
		public string BackdropPath { get; set; }
		public object BelongsToCollection { get; set; }
		public int Budget { get; set; }
		[JsonProperty(ItemConverterType = typeof(GenresJsonItemConverter))]
		public List<Genre> Genres { get; set; } //class
		public string Homepage { get; set; }
		public int Id { get; set; }
		public string ImdbId { get; set; }
		public string OriginalLanguage { get; set; }
		public string OriginalTitle { get; set; }
		public string Overview { get; set; }
		public double Popularity { get; set; }
		public string PosterPath { get; set; }
		[JsonProperty(ItemConverterType = typeof(NameJsonItemConverter))]
		public List<string> ProductionCompanies { get; set; } //class
		[JsonProperty(ItemConverterType = typeof(NameJsonItemConverter))]
		public List<string> ProductionCountries { get; set; } //class
		public string ReleaseDate { get; set; }
		public int Revenue { get; set; }
		public int Runtime { get; set; }
		[JsonProperty(ItemConverterType = typeof(NameJsonItemConverter))]
		public List<string> SpokenLanguages { get; set; } //class
		public string Status { get; set; }
		public string Tagline { get; set; }
		public string Title { get; set; }
		public bool Video { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}
}