using Bogus;
using BirrasBares.Models;
using BirrasBares.Utilities;
using System.Collections.Generic;

namespace BirrasBares.Data
{
    public static class FakeDataGenerator
    {
        private static readonly string[] NombresBares = new[] { "La Taberna del Lúpulo", "Cervecería El Barril", "The Hop House", "El Rincón de la Cerveza", "La Fábrica", "Bierhaus München", "The Crafty Brewpub", "El Bebedero", "La Cervecería Artesanal", "Taproom 73" };
        private static readonly string[] TiposBares = new[] { "Pub irlandés", "Cervecería artesanal", "Bar de tapas", "Gastropub", "Sports Bar", "Brewpub", "Beer Garden", "Taberna tradicional" };

        private static readonly string[] MarcasCerveza = new[] { "BrewMaster", "HopHeaven", "MaltMania", "CraftKings", "BarrelAged", "PureBrew", "ArtesanalCo", "LúpuloLoco", "CervezArtista", "MicroBrew" };
        private static readonly string[] EstilosCerveza = new[] { "Lager", "IPA", "Stout", "Wheat Beer", "Pale Ale", "Pilsner", "Porter", "Brown Ale", "Sour", "Saison", "Barleywine", "Bock", "Doppelbock", "Hefeweizen", "Dunkel", "Kölsch" };
        private static readonly string[] ColoresCerveza = new[] { "Dorada", "Ámbar", "Rubia", "Negra", "Rojiza", "Cobriza", "Caramelo", "Pálida", "Oscura", "Caoba" };
        private static readonly string[] DescriptoresAroma = new[] { "Afrutado", "Floral", "Cítrico", "Maltoso", "Especiado", "Herbáceo", "Caramelo", "Tropical", "Resinoso", "Tostado" };
        private static readonly string[] DescriptoresSabor = new[] { "Amargo", "Dulce", "Ácido", "Maltoso", "Afrutado", "Especiado", "Tostado", "Caramelizado", "Cítrico", "Equilibrado" };
        private static readonly string[] OpcionesMariaje = new[] { "Carnes a la parrilla", "Pescados", "Quesos fuertes", "Postres", "Tapas variadas", "Comida picante", "Mariscos", "Pasta", "Ensaladas", "Comida mexicana" };

        private static readonly string[] CategoriasPlatoMenu = new[] { "Tapas", "Raciones", "Entrantes", "Platos principales", "Postres", "Para picar", "Especialidades de la casa" };
        private static readonly string[] NombresPlatos = new[] { "Patatas bravas", "Croquetas caseras", "Tabla de quesos", "Nachos con guacamole", "Alitas de pollo", "Calamares a la romana", "Hamburguesa gourmet", "Ensalada César", "Tortilla española", "Pulpo a la gallega", "Paella mixta", "Tarta de queso", "Brownie con helado", "Tiramisú casero" };
        private static readonly string[] Alergenos = new[] { "Gluten", "Lácteos", "Frutos secos", "Huevo", "Pescado", "Crustáceos", "Soja", "Apio", "Mostaza", "Sésamo" };
        private static readonly string[] Ingredientes = new[] { "Patatas", "Huevos", "Cebolla", "Ajo", "Tomate", "Pimiento", "Queso", "Jamón", "Pollo", "Ternera", "Atún", "Salmón", "Arroz", "Pan", "Aceite de oliva", "Especias" };
        private static readonly string[] TamañosPorcion = new[] { "Individual", "Para compartir", "Grande", "Mediano", "Pequeño", "Tapa" };
        private static readonly string[] Temporadas = new[] { "Todo el año", "Verano", "Invierno", "Primavera", "Otoño", "Navidad", "Semana Santa" };
        private static readonly string[] MetodosPreparacion = new[] { "A la plancha", "Frito", "Al horno", "A la parrilla", "Salteado", "Crudo", "Estofado", "Al vapor", "Ahumado", "En su jugo" };


        public static List<Bar> GenerateFakeBars(int count)
        {
            var barFaker = new Faker<Bar>("es")
               .RuleFor(b => b.Nombre, f => StringUtils.SafeSubstring(f.Company.CompanyName(), 100))
                .RuleFor(b => b.Direccion, f => StringUtils.SafeSubstring(f.Address.FullAddress(), 200))
                .RuleFor(b => b.Telefono, f => StringUtils.SafeSubstring(f.Phone.PhoneNumber(), 20))
                .RuleFor(b => b.Email, (f, b) => StringUtils.SafeSubstring(f.Internet.Email(b.Nombre), 100))
                .RuleFor(b => b.SitioWeb, f => StringUtils.SafeSubstring(f.Internet.Url(), 100))
                .RuleFor(b => b.Descripcion, f => StringUtils.SafeSubstring(f.Lorem.Paragraph(), 500))
                .RuleFor(b => b.Capacidad, f => f.Random.Number(30, 150))
                .RuleFor(b => b.AñoApertura, f => f.Random.Number(1980, 2023))
                .RuleFor(b => b.TipoBar, f => f.PickRandom(TiposBares))
                .RuleFor(b => b.TieneTerraza, f => f.Random.Bool())
                .RuleFor(b => b.PermiteReservas, f => f.Random.Bool())
                .RuleFor(b => b.ServiciosAdicionales, f =>
                {
                    var servicios = string.Join(", ", f.Make(f.Random.Number(1, 3), () => f.PickRandom("WiFi", "Dardos", "Billar", "Karaoke")));
                    return StringUtils.SafeSubstring(servicios, 200);
                })
                .RuleFor(b => b.Ambiente, f => f.PickRandom("Acogedor", "Animado", "Rústico", "Moderno", "Tradicional"))
                .RuleFor(b => b.RangoPrecios, f => f.PickRandom("€", "€€", "€€€"))
                .RuleFor(b => b.CalificacionPromedio, f => Math.Round(f.Random.Decimal(3.5m, 4.9m), 1))
                .RuleFor(b => b.ImagenUrl, f => StringUtils.SafeSubstring(f.Internet.Url(), 200))
                .RuleFor(b => b.RedesSociales, f =>
                {
                    var redes = $"FB: /{f.Internet.UserName()}, IG: @{f.Internet.UserName()}";
                    return StringUtils.SafeSubstring(redes, 200);
                })
                .RuleFor(b => b.Propietario, f => StringUtils.SafeSubstring(f.Name.FullName(), 100))
                .RuleFor(b => b.AccesibilidadDiscapacitados, f => f.Random.Bool())
                .RuleFor(b => b.Especialidades, f =>
                {
                    var especialidades = string.Join(", ", f.Make(f.Random.Number(2, 4), () => f.PickRandom("Cervezas locales", "Tapas", "Maridajes")));
                    return StringUtils.SafeSubstring(especialidades, 200);
                });

            return barFaker.Generate(count);
        }

        public static List<Cerveza> GenerateFakeBeers(int count)
        {
            var cervezaFaker = new Faker<Cerveza>("es")
                .RuleFor(c => c.Nombre, f => StringUtils.SafeSubstring($"{f.PickRandom("La", "El")} {f.Commerce.ProductName()}", 100))
                .RuleFor(c => c.Marca, f => f.PickRandom(MarcasCerveza))
                .RuleFor(c => c.Estilo, f => f.PickRandom(EstilosCerveza))
                .RuleFor(c => c.Graduacion, f => Math.Round(f.Random.Decimal(4.0m, 10.0m), 1))
                .RuleFor(c => c.IBU, f => f.Random.Number(10, 100))
                .RuleFor(c => c.Descripcion, f => StringUtils.SafeSubstring(
                    $"Una cerveza {f.PickRandom("refrescante", "intensa", "equilibrada", "compleja")} con notas de " +
                    $"{f.PickRandom("cítricos", "frutas tropicales", "caramelo", "café", "chocolate", "especias")} y un final " +
                    $"{f.PickRandom("seco", "amargo", "dulce", "suave")}.", 500))
                .RuleFor(c => c.PaisOrigen, f => StringUtils.SafeSubstring(f.Address.Country(), 50))
                .RuleFor(c => c.AñoLanzamiento, f => f.Random.Number(2010, 2023))
                .RuleFor(c => c.Calorias, f => f.Random.Number(30, 300))
                .RuleFor(c => c.Color, f => f.PickRandom(ColoresCerveza))
                .RuleFor(c => c.Aroma, f => StringUtils.SafeSubstring(string.Join(", ", f.PickRandom(DescriptoresAroma, 3)), 200))
                .RuleFor(c => c.Sabor, f => StringUtils.SafeSubstring(string.Join(", ", f.PickRandom(DescriptoresSabor, 3)), 200))
                .RuleFor(c => c.Maridaje, f => StringUtils.SafeSubstring(string.Join(", ", f.PickRandom(OpcionesMariaje, 2)), 200))
                .RuleFor(c => c.EsArtesanal, f => f.Random.Bool(0.7f))
                .RuleFor(c => c.DisponibleTodoElAño, f => f.Random.Bool(0.8f))
                .RuleFor(c => c.ImagenUrl, f => StringUtils.SafeSubstring(f.Image.PicsumUrl(), 200));

            return cervezaFaker.Generate(count);
        }

        public static List<PlatoMenu> GenerateFakePlatosMenu(int count, List<Bar> bares)
        {
            var platoMenuFaker = new Faker<PlatoMenu>("es")
                .RuleFor(p => p.Nombre, f => StringUtils.SafeSubstring(f.PickRandom(NombresPlatos), 100))
                .RuleFor(p => p.Descripcion, f => StringUtils.SafeSubstring($"Delicioso plato de {f.Lorem.Words(3)} preparado con {f.Lorem.Words(2)} y acompañado de {f.Lorem.Word()}", 500))
                .RuleFor(p => p.Precio, f => Math.Round(f.Random.Decimal(5, 50), 2))
                .RuleFor(p => p.Categoria, f => f.PickRandom(CategoriasPlatoMenu))
                .RuleFor(p => p.Disponible, f => f.Random.Bool(0.9f))
                .RuleFor(p => p.ImagenUrl, f => StringUtils.SafeSubstring(f.Image.PicsumUrl(), 200))
                .RuleFor(p => p.EsVegano, f => f.Random.Bool(0.1f))
                .RuleFor(p => p.EsVegetariano, f => f.Random.Bool(0.2f))
                .RuleFor(p => p.EsSinGluten, f => f.Random.Bool(0.1f))
                .RuleFor(p => p.Alergenos, f => StringUtils.SafeSubstring(string.Join(", ", f.PickRandom(Alergenos, f.Random.Number(0, 3))), 200))
                .RuleFor(p => p.Ingredientes, f => StringUtils.SafeSubstring(string.Join(", ", f.PickRandom(Ingredientes, f.Random.Number(3, 8))), 500))
                .RuleFor(p => p.Calorias, f => f.Random.Number(100, 1000))
                .RuleFor(p => p.TamañoPorcion, f => f.PickRandom(TamañosPorcion))
                .RuleFor(p => p.EsEspecialidad, f => f.Random.Bool(0.2f))
                .RuleFor(p => p.Temporada, f => f.PickRandom(Temporadas))
                .RuleFor(p => p.Popularidad, f => f.Random.Number(1, 5))
                .RuleFor(p => p.Preparacion, f => f.PickRandom(MetodosPreparacion))
                .RuleFor(p => p.Bar, f => f.PickRandom(bares));

            return platoMenuFaker.Generate(count);
        }

        public static List<BarCerveza> GenerateFakeBarCervezas(List<Bar> bares, List<Cerveza> cervezas)
        {
            var barCervezas = new List<BarCerveza>();
            var faker = new Faker();

            foreach (var bar in bares)
            {
                // Determinar el número de cervezas para este bar
                var numCervezas = faker.Random.Number(5, Math.Min(20, cervezas.Count));

                // Seleccionar cervezas aleatorias para este bar
                var cervezasForThisBar = faker.PickRandom(cervezas, numCervezas);

                foreach (var cerveza in cervezasForThisBar)
                {
                    // Calcular el precio basado en si la cerveza es artesanal y su graduación
                    var precioBase = cerveza.EsArtesanal ? faker.Random.Decimal(3, 6) : faker.Random.Decimal(2, 4);
                    var precioGraduacion = cerveza.Graduacion * 0.2m; // Aumenta el precio ligeramente basado en la graduación
                    var precioFinal = Math.Round(precioBase + precioGraduacion, 2);

                    barCervezas.Add(new BarCerveza
                    {
                        Bar = bar,
                        Cerveza = cerveza,
                        Precio = precioFinal
                    });
                }
            }

            return barCervezas;
        }

        public static List<HorarioBar> GenerateFakeHorarios(List<Bar> bares)
        {
            var horarios = new List<HorarioBar>();
            var faker = new Faker();

            foreach (var bar in bares)
            {
                for (int dia = 1; dia <= 7; dia++)
                {
                    // Algunos bares pueden estar cerrados ciertos días
                    if (faker.Random.Bool(0.9f))  // 90% de probabilidad de estar abierto
                    {
                        var horaApertura = new TimeSpan(faker.Random.Number(11, 14), 0, 0);  // Entre 11:00 y 14:00
                        var hCierre = faker.Random.Number(22, 28);
                        if (hCierre >= 24)
                            hCierre -= 24;
                        var horaCierre = new TimeSpan(hCierre, 0, 0);  // Entre 22:00 y 04:00 del día siguiente

                        horarios.Add(new HorarioBar
                        {
                            Bar = bar,
                            DiaSemana = dia,
                            HoraApertura = horaApertura,
                            HoraCierre = horaCierre,
                            Descripcion = string.Empty
                            // Podríamos añadir horarios especiales para ciertas fechas si es necesario
                        });
                    }
                }
            }

            return horarios;
        }

        public static List<Evento> GenerateFakeEventos(List<Bar> bares, int count)
        {
            var eventos = new List<Evento>();
            var faker = new Faker();

            var tiposEvento = new[] {
                "Concierto en vivo", "Noche de karaoke", "Cata de cervezas",
                "Partido de fútbol", "Quiz night", "Happy hour",
                "Noche temática", "DJ invitado", "Cerveza artesanal",
                "Competencia de tapas", "Noche de comedia", "Fiesta de disfraces"
            };

            for (int i = 0; i < count; i++)
            {
                var bar = faker.PickRandom(bares);
                var fechaEvento = faker.Date.Future(1);  // Evento en el próximo año

                var horaInicio = new TimeSpan(faker.Random.Number(18, 22), 0, 0);  // Entre 18:00 y 22:00
                var duracionHoras = faker.Random.Number(2, 6);  // Duración entre 2 y 6 horas
                var hFin = horaInicio.Hours + duracionHoras;
                if (hFin >= 24)
                    hFin -= 24;
                var horaFin = new TimeSpan(hFin, 0, 0);

                eventos.Add(new Evento
                {
                    Nombre = StringUtils.SafeSubstring(faker.PickRandom(tiposEvento), 100),
                    Fecha = fechaEvento,
                    Descripcion = StringUtils.SafeSubstring(faker.Lorem.Paragraph(), 500),
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                    Precio = faker.Random.Bool(0.7f) ? (decimal?)null : Math.Round(faker.Random.Decimal(5, 20), 2),
                    Capacidad = faker.Random.Bool(0.8f) ? faker.Random.Number(20, 100) : (int?)null,
                    Bar = bar
                });
            }

            return eventos;
        }

        public static void InitializeWithFakeData(ApplicationDbContext context)
        {
            if (!context.Bares.Any() && !context.Cervezas.Any() && !context.PlatosMenu.Any() && !context.BaresCervezas.Any())
            {
                var bares = GenerateFakeBars(10);
                context.Bares.AddRange(bares);
                context.SaveChanges();

                var cervezas = GenerateFakeBeers(50);
                context.Cervezas.AddRange(cervezas);
                context.SaveChanges();

                var platosMenu = GenerateFakePlatosMenu(100, bares);
                context.PlatosMenu.AddRange(platosMenu);
                context.SaveChanges();

                var barCervezas = GenerateFakeBarCervezas(bares, cervezas);
                context.BaresCervezas.AddRange(barCervezas);
                context.SaveChanges();

                var horarios = GenerateFakeHorarios(bares);
                context.HorariosBar.AddRange(horarios);
                context.SaveChanges();

                var eventos = GenerateFakeEventos(bares, 50);  // Genera 50 eventos
                context.Eventos.AddRange(eventos);
                context.SaveChanges();
            }
        }
    }
}