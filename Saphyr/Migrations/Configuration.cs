namespace Saphyr.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Saphyr.Context.SaphyrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //impede a recriacao do banco
            Database.SetInitializer<Saphyr.Context.SaphyrContext>(null);
        }

        protected override void Seed(Saphyr.Context.SaphyrContext context)
        {
            //usado somente quando banco ta zerado
            //populaGerentes(context);
            //populaShoppings(context);
            //populaLojas(context);
            
        }

        private void populaGerentes(Saphyr.Context.SaphyrContext context)
        {
            IList<Models.Gerente> gerentes = new List<Models.Gerente>
            {
                new Models.Gerente { Nome = "João Silva", Matricula= "1234" },
                new Models.Gerente { Nome = "Maria Barros" , Matricula= "5678" },
                new Models.Gerente { Nome = "José dos Santos" , Matricula= "9876" },
                new Models.Gerente { Nome = "Marcelo Andrade", Matricula= "5432" }
            };

            foreach (Models.Gerente ger in gerentes)
                context.Gerentes.Add(ger);
            base.Seed(context);
        }

        private void populaShoppings(Saphyr.Context.SaphyrContext context)
        {
            IList<Models.Shopping> shoppings = new List<Models.Shopping>
            {
                new Models.Shopping {Nome = "Shopping Jardim Guadalupe", AreaTotal= 4567,GerenteId = 2,NumeroPiso=1 ,Endereco="Guadalupe" },
                new Models.Shopping {Nome = "Pátio Cianê Shopping", AreaTotal= 789,GerenteId = 3,NumeroPiso=3 ,Endereco="Cianê" },
                new Models.Shopping {Nome = "SuperShopping Osasco", AreaTotal= 3457,GerenteId = 4,NumeroPiso=5 ,Endereco="Osasco" },
                new Models.Shopping {Nome = "Bossa Nova Mall", AreaTotal= 8765,GerenteId = 1,NumeroPiso=0 ,Endereco="Centro" },
                new Models.Shopping {Nome = "Via Verde Shopping", AreaTotal= 3245,GerenteId = 2,NumeroPiso=2 ,Endereco="Centro" },
                new Models.Shopping {Nome = "Shopping Pátio Maceió", AreaTotal= 65465,GerenteId = 3,NumeroPiso=4 ,Endereco="Maceió" },
                new Models.Shopping {Nome = "Monte Carmo Shopping", AreaTotal= 9699,GerenteId = 4,NumeroPiso=5 ,Endereco="Monte Carmo" },
                new Models.Shopping {Nome = "Shopping Manaus ViaNorte", AreaTotal= 1224,GerenteId = 1,NumeroPiso=3 ,Endereco="Norte" },
                new Models.Shopping {Nome = "Fashion Mall", AreaTotal= 5678,GerenteId = 2,NumeroPiso=0 ,Endereco="São Conrado" },
                new Models.Shopping {Nome = "Serrasul Shopping", AreaTotal= 96567,GerenteId = 3,NumeroPiso=3 ,Endereco="Centro" },
                new Models.Shopping {Nome = "Shopping Spazio Ouro Verde", AreaTotal= 1244,GerenteId = 4,NumeroPiso=4 ,Endereco="Ouro Verde" },
                new Models.Shopping {Nome = "Pátio Roraima Shopping", AreaTotal= 43545,GerenteId = 1,NumeroPiso=7 ,Endereco="Zona Sul" },
                new Models.Shopping {Nome = "Cosmopolitano Shopping", AreaTotal= 3224,GerenteId = 2,NumeroPiso=4 ,Endereco="Centro" },
                new Models.Shopping {Nome = "Shopping Metrô Tucuruvi", AreaTotal= 5533,GerenteId = 3,NumeroPiso=2 ,Endereco="Zona Leste" },
                new Models.Shopping {Nome = "Shopping Granja Vianna", AreaTotal= 3243,GerenteId = 4,NumeroPiso=1 ,Endereco="Zona Norte" },
                new Models.Shopping {Nome = "Shopping Paralela", AreaTotal= 4234,GerenteId = 1,NumeroPiso=3 ,Endereco="Centro" }

            };

            foreach (Models.Shopping sp in shoppings)
                context.Shoppings.Add(sp);
            base.Seed(context);
        }


        private void populaLojas(Saphyr.Context.SaphyrContext context)
        {
            IList<Models.Loja> lojas = new List<Models.Loja>
            {
                new Models.Loja {Nome = "Lojas Americanas", Localizacao="23",ShoppingId=1, CNPJ="987987" },
                new Models.Loja {Nome = "McDonalds", Localizacao="65",ShoppingId=1, CNPJ="324239" },
                new Models.Loja {Nome = "Aviator", Localizacao="66",ShoppingId=1, CNPJ="8678678" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="345",ShoppingId=1, CNPJ="8678670" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="321",ShoppingId=2, CNPJ="423423" },
                new Models.Loja {Nome = "McDonalds", Localizacao="657",ShoppingId=2, CNPJ="765765" },
                new Models.Loja {Nome = "Aviator", Localizacao="577",ShoppingId=2, CNPJ="42344" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="89",ShoppingId=2, CNPJ="4236" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="66",ShoppingId=3, CNPJ="64564" },
                new Models.Loja {Nome = "McDonalds", Localizacao="878",ShoppingId=3, CNPJ="6456" },
                new Models.Loja {Nome = "Aviator", Localizacao="333",ShoppingId=3, CNPJ="654645" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="642",ShoppingId=3, CNPJ="645645" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="656",ShoppingId=4, CNPJ="8678" },
                new Models.Loja {Nome = "McDonalds", Localizacao="78",ShoppingId=4, CNPJ="87867" },
                new Models.Loja {Nome = "Aviator", Localizacao="66",ShoppingId=4, CNPJ="345345" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="22",ShoppingId=4, CNPJ="534534" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="99",ShoppingId=5, CNPJ="354534" },
                new Models.Loja {Nome = "McDonalds", Localizacao="45",ShoppingId=5, CNPJ="45435" },
                new Models.Loja {Nome = "Aviator", Localizacao="23",ShoppingId=5, CNPJ="34534" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="85",ShoppingId=5, CNPJ="34543" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="224",ShoppingId=6, CNPJ="32232" },
                new Models.Loja {Nome = "McDonalds", Localizacao="663",ShoppingId=6, CNPJ="5354" },
                new Models.Loja {Nome = "Aviator", Localizacao="44",ShoppingId=6, CNPJ="07087" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="91",ShoppingId=6, CNPJ="55345" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="553",ShoppingId=7, CNPJ="5345" },
                new Models.Loja {Nome = "McDonalds", Localizacao="351",ShoppingId=7, CNPJ="2323" },
                new Models.Loja {Nome = "Aviator", Localizacao="369",ShoppingId=7, CNPJ="97987" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="437",ShoppingId=7, CNPJ="4645" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="323",ShoppingId=8, CNPJ="6457" },
                new Models.Loja {Nome = "McDonalds", Localizacao="567",ShoppingId=8, CNPJ="43234" },
                new Models.Loja {Nome = "Aviator", Localizacao="343",ShoppingId=8, CNPJ="2826" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="11",ShoppingId=8, CNPJ="2838" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="454A",ShoppingId=9, CNPJ="45345" },
                new Models.Loja {Nome = "McDonalds", Localizacao="788",ShoppingId=9, CNPJ="53454" },
                new Models.Loja {Nome = "Aviator", Localizacao="224",ShoppingId=9, CNPJ="3255" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="378",ShoppingId=9, CNPJ="7875875" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="43243",ShoppingId=10, CNPJ="26262" },
                new Models.Loja {Nome = "McDonalds", Localizacao="423",ShoppingId=10, CNPJ="62462" },
                new Models.Loja {Nome = "Aviator", Localizacao="466",ShoppingId=10, CNPJ="5434543" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="657",ShoppingId=10, CNPJ="2326" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="44",ShoppingId=11, CNPJ="6262" },
                new Models.Loja {Nome = "McDonalds", Localizacao="99",ShoppingId=11, CNPJ="22647" },
                new Models.Loja {Nome = "Aviator", Localizacao="77",ShoppingId=11, CNPJ="52748" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="345",ShoppingId=11, CNPJ="64748" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="324",ShoppingId=12, CNPJ="5556" },
                new Models.Loja {Nome = "McDonalds", Localizacao="445",ShoppingId=12, CNPJ="23423" },
                new Models.Loja {Nome = "Aviator", Localizacao="552",ShoppingId=12, CNPJ="423423" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="426",ShoppingId=12, CNPJ="42343" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="435",ShoppingId=13, CNPJ="6456" },
                new Models.Loja {Nome = "McDonalds", Localizacao="878",ShoppingId=13, CNPJ="6452" },
                new Models.Loja {Nome = "Aviator", Localizacao="55",ShoppingId=13, CNPJ="6456" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="33",ShoppingId=13, CNPJ="599" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="443",ShoppingId=14, CNPJ="454564" },
                new Models.Loja {Nome = "McDonalds", Localizacao="32",ShoppingId=14, CNPJ="6456" },
                new Models.Loja {Nome = "Aviator", Localizacao="68",ShoppingId=14, CNPJ="324" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="03",ShoppingId=14, CNPJ="43432" },

                new Models.Loja {Nome = "Lojas Americanas", Localizacao="434",ShoppingId=15, CNPJ="423432" },
                new Models.Loja {Nome = "McDonalds", Localizacao="55",ShoppingId=15, CNPJ="423423" },
                new Models.Loja {Nome = "Aviator", Localizacao="43",ShoppingId=15, CNPJ="76587" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="20",ShoppingId=15, CNPJ="87876867" },


                 new Models.Loja {Nome = "Lojas Americanas", Localizacao="33",ShoppingId=16, CNPJ="5445" },
                new Models.Loja {Nome = "McDonalds", Localizacao="12",ShoppingId=16, CNPJ="23243" },
                new Models.Loja {Nome = "Aviator", Localizacao="427",ShoppingId=16, CNPJ="86778" },
                new Models.Loja {Nome = "Cacau Show", Localizacao="757",ShoppingId=16, CNPJ="78678" }

            };

            foreach (Models.Loja loja in lojas)
                context.Lojas.Add(loja);
            base.Seed(context);
        }
    }
}
