using NUnit.Framework;
using UCL.Assets.Scripts.Components.DesignPatterns.CreationalPatterns;
using UnityEngine;

public class Singleton
{
    private class TestClass : Singleton<TestClass>
    {
    }

    private class TestClassMonoBehaviour : MonoSingleton<TestClassMonoBehaviour>
    {
        public int Test { get; set; } = 0;
    }

    [Test]
    public void TypesCheck()
    {
        Assert.True(typeof(TestClassMonoBehaviour).IsSubclassOf(typeof(MonoBehaviour)), $"The class {nameof(TestClassMonoBehaviour)} must be a subclass of MonoBehaviour");
        Assert.False(typeof(TestClass).IsSubclassOf(typeof(MonoBehaviour)), $"The class {nameof(TestClass)} mustn't be a subclass of MonoBehaviour");
    }


    [Test]
    public void AliveStateCheck()
    {
        Assert.False(TestClassMonoBehaviour.IsAlive);
        TestClassMonoBehaviour.Instance.Test = 1;
        Assert.True(TestClassMonoBehaviour.IsAlive);
    }
}

