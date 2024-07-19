$(document).ready(function() {
    var books = [];

    // Fetch book data from books.json
    $.ajax({
        url: 'books.json',
        type: 'GET',
        dataType: 'json',
        success: function(data) {
            books = data;
            // Do not display books here; only save data
        },
        error: function() {
            console.error("There was an error loading the books.");
        }
    });

    // Search functionality
    $("#search-button").on("click", function() {
        var query = $("#search-bar").val().toLowerCase();
        var results = books.filter(function(book) {
            return book.title.toLowerCase().includes(query) || book.author.toLowerCase().includes(query);
        });

        displayResults(results);
    });

    $("#search-bar").on("keypress", function(e) {
        if (e.which == 13) { // Enter key pressed
            $("#search-button").click();
        }
    });

    function displayResults(results) {
        var resultsContainer = $("#search-results");
        resultsContainer.empty();

        if (results.length > 0) {
            var resultsHtml = "<ul>";
            results.forEach(function(book) {
                resultsHtml += "<li>";
                resultsHtml += "<img src='" + book.image + "' alt='" + book.title + "' style='width: 100px; height: 150px; display: block; margin: 0 auto;'>";
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
});
