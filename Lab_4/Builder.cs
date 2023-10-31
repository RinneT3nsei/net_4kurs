using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Builder
    {
        public class Character
        {
            public string Name { get; set; }
            public int Strength { get; set; }
            public int Agility { get; set; }
            public int Intelligence { get; set; }

            public Character(string name)
            {
                Name = name;
            }
        }

        public class CharacterBuilder
        {
            private Character character;

            public CharacterBuilder(string name)
            {
                character = new Character(name);
            }

            public CharacterBuilder SetStrength(int strength)
            {
                character.Strength = strength;
                return this;
            }

            public CharacterBuilder SetAgility(int agility)
            {
                character.Agility = agility;
                return this;
            }

            public CharacterBuilder SetIntelligence(int intelligence)
            {
                character.Intelligence = intelligence;
                return this;
            }

            public Character Build()
            {
                return character;
            }
        }

        public class SQLQueryBuilder
        {
            private string query;

            public SQLQueryBuilder(string table)
            {
                query = $"SELECT * FROM {table}";
            }

            public SQLQueryBuilder Where(string condition)
            {
                query += $" WHERE {condition}";
                return this;
            }

            public SQLQueryBuilder OrderBy(string field)
            {
                query += $" ORDER BY {field}";
                return this;
            }

            public string Build()
            {
                return query;
            }
        }
    }
}
