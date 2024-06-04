namespace MatrixWordSearch.Tests;

public class CharacterMatrixTests
{
    [Fact]
    public void EmptyMatrix_Find_Fails()
    {
        CharacterMatrix matrix = new([]);

        bool result = matrix.Find("anything");

        Assert.False(result);
    }

    [Fact]
    public void SingleMatchingCharacter_Find_Succeeds()
    {
        const char anyCharacter = 'a';
        CharacterMatrix matrix = new([[anyCharacter]]);

        bool result = matrix.Find(anyCharacter.ToString());

        Assert.True(result);
    }

    [Fact]
    public void NonMatchingCharacter_Find_Fails()
    {
        const char anyCharacter = 'a';
        const char otherCharacter = 'b';
        CharacterMatrix matrix = new([[otherCharacter]]);

        bool result = matrix.Find(anyCharacter.ToString());

        Assert.False(result);
    }

    [Fact]
    public void MatchingFirstRow_Find_Succeeds()
    {
        const string topRow = "top";
        CharacterMatrix matrix = new([[.. topRow]]);

        bool result = matrix.Find(topRow);

        Assert.True(result);
    }

    [Fact]
    public void PartialRowMatch_Find_Fails()
    {
        const string someString = "test";
        CharacterMatrix matrix = new([[.. someString[..^1]]]);

        bool result = matrix.Find(someString);

        Assert.False(result);
    }

    [Fact]
    public void MatchingSecondRow_Find_Succeeds()
    {
        const string firstRow = "qwerty";
        const string secondRow = "second";
        CharacterMatrix matrix = new([[.. firstRow], [.. secondRow]]);

        bool result = matrix.Find(secondRow);

        Assert.True(result);
    }

    [Fact]
    public void EndOfRow_Find_Succeeds()
    {
        const string someString = "test";
        CharacterMatrix matrix = new([['a', .. someString]]);

        bool result = matrix.Find(someString);

        Assert.True(result);
    }

    [Fact]
    public void SpreadWordRow_Find_Fails()
    {
        const string someString = "test";
        CharacterMatrix matrix = new([[.. "teXst"]]);

        bool result = matrix.Find(someString);

        Assert.False(result);
    }

    [Fact]
    public void NearDuplicateRow_Find_Succeeds()
    {
        const string someString = "test";
        const string buffer = "XX";
        CharacterMatrix matrix = new([[.. someString[..2], .. buffer, .. someString]]);

        bool result = matrix.Find(someString);

        Assert.True(result);
    }

    [Fact]
    public void NeigbouringNearDuplicateRow_Find_Succeeds()
    {
        const string someString = "test";
        CharacterMatrix matrix = new([[.. someString[..2], .. someString]]);

        bool result = matrix.Find(someString);

        Assert.True(result);
    }

    [Fact]
    public void MatchingFirstColumn_Find_Succeeds()
    {
        const string someWord = "let";
        CharacterMatrix matrix = new([[someWord[0]], [someWord[1]], [someWord[2]]]);

        bool result = matrix.Find(someWord);

        Assert.True(result);
    }

    [Theory]
    [InlineData("FOAM", true)]
    [InlineData("MASS", true)]
    public void Example_Find_True(string text, bool expected)
    {
        CharacterMatrix matrix = new([
            ['F', 'A', 'C', 'I'],
            ['O', 'B', 'Q', 'P'],
            ['A', 'N', 'O', 'B'],
            ['M', 'A', 'S', 'S']]);

        bool result = matrix.Find(text);

        Assert.Equal(expected, result);
    }
}