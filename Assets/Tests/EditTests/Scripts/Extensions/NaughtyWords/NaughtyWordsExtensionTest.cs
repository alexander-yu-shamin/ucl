using System.Diagnostics;
using NUnit.Framework;
using UCL.Assets.Scripts.Extensions.NaughtyWords;

public class NaughtyWordsExtensionTest
{
    internal (string, string, bool)[] Statements = 
    {
        (
            "that person is an ash0le",
            "that person is an ash0le",
            false
        ),
        (
            "You're an asshole^ you are",
            "You're an ******** you are",
            true
        ),
        (
            "such as fuck off",
            "such as **** off",
            true
        ),
        (
            "SuCh as FuCk off",
            "SuCh as **** off",
            true
        ),
        (
            "fUck you",
            "**** you",
            true
        ),
        (
            "shitty fucking little pig",
            "****** ******* little pig",
            true
        ),
        (
            "shitty fucking little piggy bank",
            "****** ******* little piggy bank",
            true
        ),
        (
            "Hey !asshole*, my efuckingmail is fuckyoucunt@bitch.com",
            "Hey ********** my efuckingmail is fuckyoucunt@bitch.com",
            true
        ),
        (
            "Hey, my efuckingmail is fuckyoucunt@bitch.com",
            "Hey, my efuckingmail is fuckyoucunt@bitch.com",
            false
        ),
        (
            "that person is an ash0le",
            "that person is an ash0le",
            false
        ),
        (
            "Hey !asshole*, my efuckingmail is fuckyoucunt@bitch.com",
            "Hey ********** my efuckingmail is fuckyoucunt@bitch.com",
            true
        ),
        (
            "that person is an ash0le",
            "that person is an ash0le",
            false
        )
    };

    private (string, bool)[] NaughtyWords =
    {
        ("anal", true),
        ("aswef", true),
        ("asshole", true),
        ("beatup", true),
        ("boxmuncher", true),
        ("assshit", true),
        ("bollock", true),
        ("cumguzzler", true),
        ("faggot", true),
        ("how", false),
        ("where", false),
        ("noun", false),
        ("verbs", false),
        ("bea!tup", true),
        ("boxm@uncher", true),
        ("asss#hit", true),
        ("bol%lock", true),
        ("cum@guzzler", true),
        ("FaGgot", true),
    };

    [Test]
    public void ReplaceNightyWordsTestPasses()
    {
        foreach (var statement in Statements)
        {
            UnityEngine.Debug.Log($"Input: \t\t{statement.Item1}\nResult: \t\t{statement.Item1.ReplaceNaughtyWords('*')}\nExpected: \t{statement.Item2}\n");
            Assert.AreEqual(statement.Item2, statement.Item1.ReplaceNaughtyWords('*'));
        }
    }

    [Test]
    public void IsNaughtyWordTestPasses()
    {
        foreach (var tp in NaughtyWords)
        {
            UnityEngine.Debug.Log($"Input: \t\t{tp.Item1}\nResult: \t\t{tp.Item1.IsNaughtyWord()}\nExpected: \t{tp.Item2}\n");
            Assert.AreEqual(tp.Item1.IsNaughtyWord(), tp.Item2);
        }
    }
    
    [Test]
    public void IsThereAnyNaughtyWordsTestPasses()
    {
        foreach (var tp in Statements)
        {
            UnityEngine.Debug.Log($"Input: \t\t{tp.Item1}\nResult: \t\t{tp.Item1.IsThereAnyNaughtyWords()}\nExpected: \t{tp.Item3}\n");
            Assert.AreEqual(tp.Item1.IsThereAnyNaughtyWords(), tp.Item3);
        }
    }
}
