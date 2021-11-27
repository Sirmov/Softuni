using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void ConstructorShouldIntializeCollection()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void CreateHeroShouldNotAcceptNull()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateHeroShouldNotAcceptDuplicates()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Gosho", 16);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void RemoveShouldNotAcceptNullOrWhitespace()
    {
        HeroRepository heroRepository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    //[Test]
    //public void RemoveShouldRemoveHero()
    //{
    //    HeroRepository heroRepository = new HeroRepository();
    //    Hero hero = new Hero("Gosho", 16);
    //    heroRepository.Create(hero);
    //    Assert.True(heroRepository.Remove("Gosho"));
    //}

    [Test]
    public void GetHeroWithHighestLevelShouldWorkCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero1 = new Hero("Gosho1", 16);
        Hero hero2 = new Hero("Gosho2", 20);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        Assert.AreSame(hero2, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroShouldWorkCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero1 = new Hero("Gosho1", 16);
        Hero hero2 = new Hero("Gosho2", 20);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        Assert.AreSame(hero1, heroRepository.GetHero("Gosho1"));
    }
}