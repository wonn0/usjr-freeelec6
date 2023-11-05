-- Delete data from tables that have foreign keys referencing other tables
DELETE FROM AuthorBook;
DELETE FROM BookGenre;

-- Now, delete data from the primary tables
DELETE FROM BookReviews;
DELETE FROM Books;
DELETE FROM Authors;
DELETE FROM Genres;