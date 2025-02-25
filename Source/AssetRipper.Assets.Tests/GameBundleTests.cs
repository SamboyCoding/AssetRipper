using AssetRipper.Assets.Bundles;
using AssetRipper.VersionUtilities;

namespace AssetRipper.Assets.Tests;

public class GameBundleTests
{
	[Test]
	public void ClearTemporaryBundles_ClearsTemporaryBundles()
	{
		GameBundle gameBundle = new();
		gameBundle.AddNewTemporaryBundle();
		gameBundle.ClearTemporaryBundles();
		Assert.That(gameBundle.TemporaryBundles, Is.Empty);
	}

	[Test]
	public void AddTemporaryBundle_AddsTemporaryBundle()
	{
		GameBundle gameBundle = new();
		TemporaryBundle tempBundle = new();
		gameBundle.AddTemporaryBundle(tempBundle);
		CollectionAssert.Contains(gameBundle.TemporaryBundles, tempBundle);
	}

	[Test]
	public void AddNewTemporaryBundle_AddsNewTemporaryBundle()
	{
		GameBundle gameBundle = new();
		TemporaryBundle tempBundle = gameBundle.AddNewTemporaryBundle();
		CollectionAssert.Contains(gameBundle.TemporaryBundles, tempBundle);
	}

	[Test]
	public void HasAnyAssetCollections_ReturnsFalse()
	{
		GameBundle gameBundle = new();
		Assert.That(gameBundle.HasAnyAssetCollections(), Is.False);
	}

	[Test]
	public void AddNewProcessedCollection_AddsNewProcessedCollection()
	{
		GameBundle gameBundle = new();
		string name = "testName";
		UnityVersion version = UnityVersion.Parse("10.3.1f1");
		Collections.ProcessedAssetCollection processedCollection = gameBundle.AddNewProcessedCollection(name, version);
		Assert.Multiple(() =>
		{
			Assert.That(processedCollection.Name, Is.EqualTo(name));
			Assert.That(processedCollection.Version, Is.EqualTo(version));
		});
		CollectionAssert.Contains(gameBundle.FetchAssetCollections(), processedCollection);
	}

	[Test]
	public void GetMaxUnityVersion_ReturnsMaxUnityVersion()
	{
		GameBundle gameBundle = new();
		gameBundle.AddNewProcessedCollection("test", UnityVersion.Parse("1.0.0f1"));
		gameBundle.AddNewProcessedCollection("test2", UnityVersion.Parse("2.0.10f3"));
		gameBundle.AddNewProcessedCollection("test3", UnityVersion.Parse("3.0.0f0"));
		Assert.That(gameBundle.GetMaxUnityVersion(), Is.EqualTo(UnityVersion.Parse("3.0.0f0")));
	}
}
