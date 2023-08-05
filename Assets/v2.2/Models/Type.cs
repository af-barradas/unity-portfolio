using System.Collections.Generic;

[System.Serializable]
public class Type
{
    private string name;
    private List<string> categories;

    public Type(string name, List<string> categories)
    {
        this.name = name;
        this.categories = categories;
    }

    public string getName()
    {
        return this.name;
    }

    public List<string> getCategories()
    {
        return this.categories;
    }
}