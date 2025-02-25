using AssetRipper.Assets;
using AssetRipper.Assets.Collections;
using AssetRipper.Assets.Export;
using AssetRipper.Export.UnityProjects.Project.Collections;
using AssetRipper.Export.UnityProjects.Project.Exporters;
using AssetRipper.SourceGenerated.Classes.ClassID_213;
using AssetRipper.SourceGenerated.Classes.ClassID_687078895;

namespace AssetRipper.Export.UnityProjects.Textures
{
	/// <summary>
	/// Exports sprites as YAML assets.
	/// </summary>
	public sealed class YamlSpriteExporter : YamlExporterBase
	{
		public override bool TryCreateCollection(IUnityObjectBase asset, TemporaryAssetCollection temporaryFile, [NotNullWhen(true)] out IExportCollection? exportCollection)
		{
			exportCollection = asset switch
			{
				ISprite sprite => new AssetExportCollection<ISprite>(this, sprite),
				ISpriteAtlas => new EmptyExportCollection(),
				_ => null,
			};
			return exportCollection is not null;
		}
	}
}
