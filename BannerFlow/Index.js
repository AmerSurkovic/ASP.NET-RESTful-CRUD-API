
        var uri = 'api/banners';

        $(document).ready(function () {
            loadBanners();
        });

        function loadBanners() {
            // Send an AJAX request
            $.getJSON(uri)
                .done(function (data) {
                    // On success, 'data' contains a list of products
                    $.each(data, function (key, item) {
                        // Add a list item for the product
                        $('<li>', { text: formatItem(item) }).appendTo($('#banners'));
                    });
                });
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

        // Format for listing loaded banners
        function formatItem(item) {
            var $pls = $.parseHTML(item.Html);
            return item.Id + '.' + item.Html;
        }

        // Injecting the HTML on the page by calling ../html API endpoint
        function injectHtml() {
            $('#load_html').load("api/banners/" + $('#bannerID_html').val() + "/html");
        }

        // Add a banner
        function addBanner() {
            var sendInfo = {
                Html: $('#bannerAdd_text').val()
            };

            $.ajax({
                type: "POST",
                url: uri,
                dataType: "json",
                success: function (msg) {
                    if (msg) {
                        alert("Record was added.");
                        $('#banners').text('');
                        loadBanners();
                    } else {
                        alert("Record was not added.");
                    }
                },

                data: sendInfo
            });
        }

        // Editing a banner
        function editBanner() {
            var sendInfo = {
                Html: $('#bannerEdit_text').val()
            };

                $.ajax({
                    type: "PUT",
                    url: uri + '/' + $('#bannerEdit_id').val(),
                    dataType: "json",
                    success: function (msg) {
                        if (msg) {
                            alert("Record was edited.");
                            $('#banners').text('');
                            loadBanners();
                        } else {
                            alert("Edit not successful.");
                        }
                    },

                    data: sendInfo
            });
        }

        // Deleting a banner
        function deleteBanner() {
            $.ajax({
                url: uri + '/' + $('#bannerDelete_id').val(),
                type: 'DELETE',
                success: function (result) {
                    alert("Record deleted.");
                    $('#banners').text('');
                    loadBanners();
                }
            });
        }

