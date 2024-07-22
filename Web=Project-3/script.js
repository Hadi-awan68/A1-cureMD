$(document).ready(function() {
    // Base URL for the API
    const apiUrl = 'http://localhost:5034/api/books';

    // Function to fetch books from the API
    function fetchBooks() {
        $.ajax({
            url: apiUrl,
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                displayBooksTable(data);
                displayBooks(data, "#all-books");
            },
            error: function(xhr, status, error) {
                console.error("There was an error loading the books:", error);
            }
        });
    }

    // Function to handle search functionality
    function searchBooks(query) {
        $.ajax({
            url: apiUrl,
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                var results = data.filter(function(book) {
                    return book.title.toLowerCase().includes(query) || book.author.toLowerCase().includes(query);
                });
                displayResults(results);
            },
            error: function(xhr, status, error) {
                console.error("There was an error searching for the books:", error);
            }
        });
    }

    // Display books in a table
    function displayBooksTable(books) {
        var tableBody = $("#books-table-body");
        tableBody.empty();

        if (books.length > 0) {
            books.forEach(function(book) {
                var bookRow = "<tr>";
                bookRow += "<td>" + book.title + "</td>";
                bookRow += "<td>" + book.author + "</td>";
                bookRow += "<td>" + book.price + "</td>";
                bookRow += "</tr>";
                tableBody.append(bookRow);
            });
        } else {
            tableBody.html("<tr><td colspan='3'>No books available.</td></tr>");
        }
    }

    // Display books in a list
    function displayBooks(books, container) {
        var container = $(container);
        container.empty();

        if (books.length > 0) {
            var booksHtml = "<ul>";
            books.forEach(function(book) {
                booksHtml += "<li>";
                booksHtml += "<img src='" + book.imageUrl + "' alt='" + book.title + "' style='width: 100px; height: 150px; display: block; margin: 0 auto;'>";
                booksHtml += "<h3>" + book.title + "</h3>";
                booksHtml += "<p><strong>Author:</strong> " + book.author + "</p>";
                booksHtml += "<p>" + book.description + "</p>";
                booksHtml += "</li>";
            });
            booksHtml += "</ul>";
            container.html(booksHtml);
        } else {
            container.html("<p>No books available.</p>");
        }
    }

    // Display search results
    function displayResults(results) {
        var resultsContainer = $("#search-results");
        resultsContainer.empty();

        if (results.length > 0) {
            var resultsHtml = "<ul>";
            results.forEach(function(book) {
                resultsHtml += "<li>";
                resultsHtml += "<img src='" + book.imageUrl + "' alt='" + book.title + "' style='width: 100px; height: 150px; display: block; margin: 0 auto;'>";
                resultsHtml += "<h3>" + book.title + "</h3>";
                resultsHtml += "<p><strong>Author:</strong> " + book.author + "</p>";
                resultsHtml += "<p>" + book.description + "</p>";
                resultsHtml += "</li>";
            });
            resultsHtml += "</ul>";
            resultsContainer.html(resultsHtml);
        } else {
            resultsContainer.html("<p>No results found.</p>");
        }
    }

    // Handle form submission for adding a new book
    $("#add-book-form").on("submit", function(e) {
        e.preventDefault();

        var newBook = {
            title: $("#title").val(),
            author: $("#author").val(),
            description: $("#description").val(),
            imageUrl: $("#image-url").val(),
            price: "$" + (Math.floor(Math.random() * 30) + 10).toFixed(2) // Random price between $10 and $40
        };

        $.ajax({
            url: apiUrl,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newBook),
            success: function(data) {
                // Append new book to the table
                displayBooksTable([data]);
                alert("Book added successfully!");
                $("#add-book-form")[0].reset(); // Clear the form
            },
            error: function(xhr, status, error) {
                console.error("There was an error adding the book:", error);
            }
        });
    });

    // Fetch books when the page loads
    fetchBooks();

    // Handle search functionality
    $("#search-button").on("click", function() {
        var query = $("#search-bar").val().toLowerCase();
        searchBooks(query);
    });

    $("#search-bar").on("keypress", function(e) {
        if (e.which == 13) { // Enter key pressed
            $("#search-button").click();
        }
    });
});
