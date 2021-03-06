﻿namespace WhatAChamp
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Newtonsoft.Json;
	using UserInterface.Resources;

	public static class ChampionReader
	{
		public static IEnumerable<Champion> LoadedChampions;

		public static IEnumerable<Champion> GetList()
		{
			var jsonFromTextFile = ChampionsJson.Characters;
			var championsList = JsonConvert.DeserializeObject<ChampionWrapper>(jsonFromTextFile);

			return ApplyImagesPath(championsList);
		}
		private static IEnumerable<Champion> ApplyImagesPath(ChampionWrapper champions)
		{
			LoadedChampions = champions.Data.Where(c =>
			{
				var basePath = @"pack://application:,,,/WhatAChamp;component/UserInterface/Images/Champions";

				var basePathSkills = $@"{basePath}/Skills/";
				var basePathSquare = $@"{basePath}/Square/";
				var basePathMainArt = $@"{basePath}/MainArt/";

				c.Value.image.iconPath = $@"{basePathSquare}{c.Value.name}Square.png";
				c.Value.image.originalLoadingPath = $@"{basePathMainArt}{c.Value.name}_OriginalLoading.jpg";

				c.Value.image.passivePath = $@"{basePathSkills}{c.Value.name}_P.png";
				c.Value.image.QPath = $@"{basePathSkills}{c.Value.name}_Q.png";
				c.Value.image.WPath = $@"{basePathSkills}{c.Value.name}_W.png";
				c.Value.image.EPath = $@"{basePathSkills}{c.Value.name}_E.png";
				c.Value.image.RPath = $@"{basePathSkills}{c.Value.name}_R.png";

				return true;
			}).Select(c => c.Value).OrderBy(c => c.name).ToList();

			return LoadedChampions;
		}
	}
}
