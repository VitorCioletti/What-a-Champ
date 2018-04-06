﻿namespace riotAPI_teste.APIConnection
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Newtonsoft.Json;

	public static class ChampionReader
	{
		public static IEnumerable<Champion> GetList() =>
			GetChampionsInRepository(JsonConvert.DeserializeObject<ChampionWrapper>(new StreamReader("Characters.txt").ReadToEnd()));

		private static IEnumerable<Champion> GetChampionsInRepository(ChampionWrapper champions)
		{
			return champions.Data.Where(c =>
			{
				c.Value.image.iconPath = $@"Images\Champions\Square\{c.Value.name}Square.png";
				c.Value.image.originalLoadingPath = $@"Images\Champions\MainArt\{c.Value.name}_OriginalLoading.jpg";

				c.Value.image.passivePath = $@"Images\Champions\Skills\{c.Value.name}_P.png";
				c.Value.image.QPath = $@"Images\Champions\Skills\{c.Value.name}_P.png";
				c.Value.image.WPath = $@"Images\Champions\Skills\{c.Value.name}_W.png";
				c.Value.image.EPath = $@"Images\Champions\Skills\{c.Value.name}_E.png";
				c.Value.image.RPath = $@"Images\Champions\Skills\{c.Value.name}_R.png";

				return true;
			}).Select(c => c.Value).OrderBy(c => c.name).ToList();
		}
	}
}