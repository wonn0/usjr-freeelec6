using ASI.Basecode.Data.Models;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data
{
    public partial class AsiBasecodeDBContext : IdentityDbContext<IdentityUser>
    {

        public AsiBasecodeDBContext(DbContextOptions<AsiBasecodeDBContext> options)
            : base(options)
        {
        }

        public void InsertNew(RefreshToken token)
        {
            var tokenModel = RefreshToken.SingleOrDefault(i => i.Username == token.Username);
            if (tokenModel != null)
            {
                RefreshToken.Remove(tokenModel);
                SaveChanges();
            }
            RefreshToken.Add(token);
            SaveChanges();
        }

        private readonly Random random = new Random(); // Class level Random instance

        public virtual DbSet<RefreshToken> RefreshToken { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<BookReview> BookReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AuthorBook>()
            .HasKey(ab => new { ab.AuthorId, ab.BookId });
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId);
            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<BookReview>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(br => br.BookId);

            OnModelCreatingPartial(modelBuilder);

            SeedDatabase(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var authors = GenerateRealisticAuthors();
            var genres = GenerateRealisticGenres();
            var books = new List<Book>();
            var authorBooks = new List<AuthorBook>();
            var bookGenres = new List<BookGenre>();
            var bookTitles = new List<string>
            {
                "Whispers of the Forgotten City",
                "The Last Symphony of Autumn",
                "Echoes in the Starless Sky",
                "Secrets of the Jade Labyrinth",
                "The Clockmaker's Illusion",
                "Shadows over Valoria",
                "Beneath the Crimson Moon",
                "The Garden of Timeless Secrets",
                "Veil of the Northern Lights",
                "Mysteries of the Ancient Library",
                "The Emerald Conundrum",
                "Sands of the Forgotten Empire",
                "The Painter's Paradox",
                "Voices from the Hollow Mountains",
                "Twilight of the Celestial Court",
                "Chronicles of the Silver Mist",
                "Dreams of the Sunken City",
                "Lost in the Whispering Forest",
                "The Architect's Legacy",
                "Tales from the Sapphire Sea",
                "The Alchemist's Shadow",
                "Dance of the Fireflies",
                "The Oracle's Last Prophecy",
                "Mysteries at the Edge of the Universe",
                "The Enigma of the Crystal Towers",
                "The Rose of the Wastelands",
                "Ghosts of the Ancient Manor",
                "The Forgotten Chronicles",
                "Abyss of the Starry Depths",
                "The Phoenix's Requiem",
                "The Scribe's Enigma",
                "In the Heart of the Storm",
                "The Secret of the Astral Plane",
                "The Midnight Carousel",
                "The Meridian of Fate",
                "Whispers from the Other Side",
                "The Labyrinth of Lost Souls",
                "Sorrows of the Last Warlock",
                "The Silver Key of Dreams",
                "The Hidden Kingdom Beyond the Mountains",
                "The Magician's Reflection",
                "Beyond the Shadow Realm",
                "The Ivory Tower of Secrets",
                "The Heirloom of Forgotten Times",
                "Eclipses of the Past",
                "The Dragon's Heir",
                "The Last Voyage of the Star Sailor",
                "Chronicle of the Shattered Lands",
                "The Sorceress's Labyrinth",
                "Legends of the Celestial Atlas"
};
            var bookImages = new List<string>
            {
                 "https://bukovero.com/wp-content/uploads/2016/07/Harry_Potter_and_the_Cursed_Child_Special_Rehearsal_Edition_Book_Cover.jpg",
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCBozk3sxY9-hx2apV246Aop5hzCKe1Yoe2I_bVICUPiXNu5IXSaeKY0rWJt5qOVEYMRo&usqp=CAU",
        "https://i0.wp.com/allaboutbookcovers.com/wp-content/uploads/2022/06/CourtOfThorns-copy.jpg?fit=1350%2C2025&ssl=1",
        "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/contemporary-fiction-night-time-book-cover-design-template-1be47835c3058eb42211574e0c4ed8bf_screen.jpg?ts=1698210220",
        "https://www.adobe.com/express/create/cover/media_1316972d23c5f2032e101572da69ae4aec3259fed.jpeg?width=400&format=jpeg&optimize=medium",
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSDQnigiVI5kU-UYO_Ourb8H5uaXUP-FYYZ7SFSqMSPTb3ZcCxg2rBwRqcINTKAp7uVNQ&usqp=CAU",
        "https://encrypted-tbn0.gstatic.com/images?qcd=tbn:ANd9GcRWlgwga9KKQCQo2tPQ1-vkIEdIFX9Dp7OJwg&usqp=CAU",
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTP-NlVbe_m7VER_lfAVbKpyo2Shp9Wv6pLMg&usqp=CAU",
        "https://1stwebdesigner.com/wp-content/uploads/2011/05/the-great-gatsby.jpg","https://compote.slate.com/images/4262aedd-78f0-4669-a1b9-c7d08c67897a.jpeg?crop=693%2C1040%2Cx0%2Cy0"

};

            // Generate books
            for (int i = 1; i <= 50; i++)
            {
                var book = new Book
                {
                    Id = i,
                    Name = bookTitles[random.Next(bookTitles.Count)],
                    Description = $"An engaging and compelling story about...",
                    ISBN = $"ISBN-{random.Next(1000, 9999)}-{random.Next(1000, 9999)}",
                    Language = "English",
                    PublishedOn = DateTime.Now.AddDays(-random.Next(365, 3650)),
                    PageCount = random.Next(100, 500),
                    Image = bookImages[random.Next(bookImages.Count)],
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    AuthorBooks = new List<AuthorBook>(),
                    BookGenres = new List<BookGenre>(),
                    BookReviews = new List<BookReview>()
                };


                books.Add(book);

                foreach (var author in authors.OrderBy(_ => random.Next()).Take(random.Next(1, 4)))
                {
                    authorBooks.Add(new AuthorBook { AuthorId = author.Id, BookId = book.Id });
                }
                foreach (var genre in genres.OrderBy(_ => random.Next()).Take(random.Next(1, 3)))
                {
                    bookGenres.Add(new BookGenre { GenreId = genre.Id, BookId = book.Id });
                }
            }

            // Add the generated data
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<AuthorBook>().HasData(authorBooks);
            modelBuilder.Entity<BookGenre>().HasData(bookGenres);
        }


        private List<Author> GenerateRealisticAuthors()
        {
            return new List<Author>
            {
                new Author { Id = 1, FirstName = "Jane", LastName = "Austen" },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell" },
                new Author { Id = 3, FirstName = "Haruki", LastName = "Murakami" },
                new Author { Id = 4, FirstName = "Toni", LastName = "Morrison" },
                new Author { Id = 5, FirstName = "Leo", LastName = "Tolstoy" },
                new Author { Id = 6, FirstName = "Gabriel García", LastName = "Márquez" },
                new Author { Id = 7, FirstName = "J.K.", LastName = "Rowling" },
                new Author { Id = 8, FirstName = "Charles", LastName = "Dickens" },
                new Author { Id = 9, FirstName = "Chimamanda Ngozi", LastName = "Adichie" },
                new Author { Id = 10, FirstName = "Ernest", LastName = "Hemingway" },
                new Author { Id = 11, FirstName = "Fyodor", LastName = "Dostoevsky" },
                new Author { Id = 12, FirstName = "Isabel", LastName = "Allende" },
                new Author { Id = 13, FirstName = "Mark", LastName = "Twain" },
                new Author { Id = 14, FirstName = "Virginia", LastName = "Woolf" },
                new Author { Id = 15, FirstName = "James", LastName = "Baldwin" },
                new Author { Id = 16, FirstName = "Agatha", LastName = "Christie" },
                new Author { Id = 17, FirstName = "J.R.R.", LastName = "Tolkien" },
                new Author { Id = 18, FirstName = "Margaret", LastName = "Atwood" },
                new Author { Id = 19, FirstName = "Kazuo", LastName = "Ishiguro" },
                new Author { Id = 20, FirstName = "Paulo", LastName = "Coelho" },
                new Author { Id = 21, FirstName = "Mary", LastName = "Shelley" },
                new Author { Id = 22, FirstName = "Salman", LastName = "Rushdie" },
                new Author { Id = 23, FirstName = "H.P.", LastName = "Lovecraft" },
                new Author { Id = 24, FirstName = "Emily", LastName = "Brontë" },
                new Author { Id = 25, FirstName = "Edgar Allan", LastName = "Poe" },
                new Author { Id = 26, FirstName = "Langston", LastName = "Hughes" },
                new Author { Id = 27, FirstName = "Khaled", LastName = "Hosseini" },
                new Author { Id = 28, FirstName = "Oscar", LastName = "Wilde" },
                new Author { Id = 29, FirstName = "Stephen", LastName = "King" },
                new Author { Id = 30, FirstName = "Maya", LastName = "Angelou" },
                new Author { Id = 31, FirstName = "Roald", LastName = "Dahl" },
                new Author { Id = 32, FirstName = "Dan", LastName = "Brown" },
                new Author { Id = 33, FirstName = "Neil", LastName = "Gaiman" },
                new Author { Id = 34, FirstName = "Sylvia", LastName = "Plath" },
                new Author { Id = 35, FirstName = "Ian", LastName = "McEwan" },
                new Author { Id = 36, FirstName = "Orhan", LastName = "Pamuk" },
                new Author { Id = 37, FirstName = "Zadie", LastName = "Smith" },
                new Author { Id = 38, FirstName = "Alice", LastName = "Walker" },
                new Author { Id = 39, FirstName = "Kurt", LastName = "Vonnegut" },
                new Author { Id = 40, FirstName = "Louise", LastName = "Erdrich" },
                new Author { Id = 41, FirstName = "Cormac", LastName = "McCarthy" },
                new Author { Id = 42, FirstName = "Philip K.", LastName = "Dick" },
                new Author { Id = 43, FirstName = "John", LastName = "Steinbeck" },
                new Author { Id = 44, FirstName = "Herman", LastName = "Melville" },
                new Author { Id = 45, FirstName = "Charles", LastName = "Bukowski" },
                new Author { Id = 46, FirstName = "William", LastName = "Faulkner" },
                new Author { Id = 47, FirstName = "Ayn", LastName = "Rand" },
                new Author { Id = 48, FirstName = "Gustave", LastName = "Flaubert" },
                new Author { Id = 49, FirstName = "Ken", LastName = "Follett" },
                new Author { Id = 50, FirstName = "Arthur Conan", LastName = "Doyle" },

                };
        }

        private List<Genre> GenerateRealisticGenres()
        {
            return new List<Genre>
            {
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Science Fiction" },
                new Genre { Id = 3, Name = "Mystery" },
                new Genre { Id = 4, Name = "Thriller" },
                new Genre { Id = 5, Name = "Romance" },
                new Genre { Id = 6, Name = "Historical Fiction" },
                new Genre { Id = 7, Name = "Horror" },
                new Genre { Id = 8, Name = "Young Adult" },
                new Genre { Id = 9, Name = "Children’s Literature" },
                new Genre { Id = 10, Name = "Literary Fiction" },
                new Genre { Id = 11, Name = "Dystopian" },
                new Genre { Id = 12, Name = "Adventure" },
                new Genre { Id = 13, Name = "Crime" },
                new Genre { Id = 14, Name = "Suspense" },
                new Genre { Id = 15, Name = "Cyberpunk" },
                new Genre { Id = 16, Name = "Magical Realism" },
                new Genre { Id = 17, Name = "Gothic" },
                new Genre { Id = 18, Name = "War" },
                new Genre { Id = 19, Name = "Post-Apocalyptic" },
                new Genre { Id = 20, Name = "Western" },
                new Genre { Id = 21, Name = "Satire" },
                new Genre { Id = 22, Name = "Biography" },
                new Genre { Id = 23, Name = "Autobiography" },
                new Genre { Id = 24, Name = "Self-Help" },
                new Genre { Id = 25, Name = "Travel" },
                new Genre { Id = 26, Name = "Cooking" },
                new Genre { Id = 27, Name = "Health & Fitness" },
                new Genre { Id = 28, Name = "Graphic Novel" },
                new Genre { Id = 29, Name = "Poetry" },
                new Genre { Id = 30, Name = "Play" },
                new Genre { Id = 31, Name = "Essays" },
                new Genre { Id = 32, Name = "Journalism" },
                new Genre { Id = 33, Name = "Steampunk" },
                new Genre { Id = 34, Name = "Paranormal" },
                new Genre { Id = 35, Name = "Urban Fantasy" },
                new Genre { Id = 36, Name = "Epic" },
                new Genre { Id = 37, Name = "Non-Fiction" },
                new Genre { Id = 38, Name = "Contemporary" },
                new Genre { Id = 39, Name = "Classic" },
                new Genre { Id = 40, Name = "Humor" },
                new Genre { Id = 41, Name = "Memoir" },
                new Genre { Id = 42, Name = "Philosophy" },
                new Genre { Id = 43, Name = "Religion" },
                new Genre { Id = 44, Name = "True Crime" },
                new Genre { Id = 45, Name = "Academic" },
                new Genre { Id = 46, Name = "Self-Improvement" },
                new Genre { Id = 47, Name = "Chick Lit" },
                new Genre { Id = 48, Name = "LGBT Literature" },
                new Genre { Id = 49, Name = "Fairy Tales" },
                new Genre { Id = 50, Name = "Bildungsroman" },
             };
        }

        private void AssignRandomAuthorsAndGenres(Book book, List<Author> authors, List<Genre> genres, Random random)
        {
            for (int i = 0; i < random.Next(1, 3); i++)
            {
                book.AuthorBooks.Add(new AuthorBook { BookId = book.Id, AuthorId = authors[random.Next(authors.Count)].Id });
                book.BookGenres.Add(new BookGenre { BookId = book.Id, GenreId = genres[random.Next(genres.Count)].Id });
            }
        }

        private void GenerateRealisticBookReviews(Book book, Random random)
        {
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                book.BookReviews.Add(new BookReview
                {
                    Id = i,
                    BookId = book.Id,
                    Email = $"reviewer{i}@book{book.Id}.com",
                    ReviewedBy = $"Reviewer {i}",
                    Description = $"I really enjoyed this book because...",
                    ReviewedOn = DateTime.Now.AddDays(-random.Next(0, 365)),
                    Rating = random.Next(1, 6)
                });
            }
        }


    }
}
