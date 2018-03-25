    var uri = 'api/banners';

        $(document).ready(function () {
        // Send an AJAX request
        $.getJSON(uri)
            .done(function (data) {
                // On success, 'data' contains a list of products
                $.each(data, function (key, item) {
                    // Add a list item for the product
                    $('<li>', { text: formatItem(item) }).appendTo($('#banners'));
                });
            });
    });

        // Format for listing loaded banners
        function formatItem(item) {
            var $pls = $.parseHTML(item.Html);
            return item.Id + ' HTML: ' + item.Html;
        }

        // Function to find a banner with set ID
        function find() {
            var id = $('#bannerID').val();
            $.getJSON(uri + '/' + id)
                .done(function (data) {
        $('#banner').text(formatItem(data));
    })
                .fail(function (jqXHR, textStatus, err) {
        $('#banner').text('Error: ' + error);
    });
        }

        // Function to find a banner for a set ID and to load its HTML on the page
        function loadHtml() {
            var id = $('#bannerID_html').val();
            $.getJSON(uri + '/' + id)
                .done(function (data) {
        $('#banner').text(injectHtml(data));
    })
                .fail(function (jqXHR, textStatus, err) {
        $('#banner').text('Error: ' + error);
    });
        }

        // Injecting the HTML on the page by calling ../html API endpoint
        function injectHtml(item) {
        $('#loadHtml').load("api/banners/" + item.Id + "/html");
    }
