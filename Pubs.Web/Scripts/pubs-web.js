var Pubs = (function ($, Modernizr) {
    var init = function () {

    }

    return {
        init: init
    }

})(jQuery, Modernizr);

Pubs.Web = (function ($, Modernizr) {
    var searchAuthor = function (startRow) {
        var redirectUrl = '/author/table/?lastName=';
        var searchTerm = $('#txtSearchLastName').val();
        var numberOfRows = 5;

        redirectUrl = redirectUrl + searchTerm + '&startRow=' + startRow;
        window.location = redirectUrl;
    }

    var searchAuthorID = function (startRow) {
        var redirectUrl = '/author/table/?authorID=';
        var searchTerm = $('#txtAuthorID').val();
        var numberOfRows = 5;

        redirectUrl = redirectUrl + searchTerm + '&startRow=' + startRow;
        window.location = redirectUrl;
    }

    var selectAuthor = function (event, author) {
        event.preventDefault(); // prevent button click from submitting the form
        if (author != '') {
            var authorIDStart = author.indexOf('(');
            var authorIDEnd = author.indexOf(')');
            if (authorIDStart > 0
                && authorIDEnd > 0) {
                var authorID = author.substring(authorIDStart + 1, authorIDEnd);
                if ($('#author-' + authorID).length == 0) {
                    var authorCheckbox = '<input type="checkbox" id="author-' + authorID + '" name="author-' + authorID + '" checked /> ' + author;
                    $("#lstAuthors").append('<li class="list-group-item">' + authorCheckbox + '</li>');
                }
            }
        }
    }

    var initAuthorTable = function (lastName, authorID) {
        $('#btnSearchAuthor').on('click', function (event) {
            event.preventDefault(); // prevent button click from submitting the form
            searchAuthor(1);
        });

        $('#btnClearAuthor').on('click', function (event) {
            event.preventDefault(); // prevent button click from submitting the form
            $('#txtSearchLastName').val('');
            searchAuthor(1);
        });

        $('#btnSearchAuthorID').on('click', function (event) {
            event.preventDefault(); // prevent button click from submitting the form
            searchAuthorID(1);
        });

        $('#btnClearAuthorID').on('click', function (event) {
            event.preventDefault(); // prevent button click from submitting the form
            $('#txtAuthorID').val('');
            searchAuthorID(1);
        });

        if (lastName != '') {
            $('#txtSearchLastName').val(lastName);
        }

        if (authorID != '') {
            $('#txtAuthorID').val(authorID);
            $('#collapseExample').collapse('show');
        }
    }

    var initTitleCreate2 = function () {
        $('#btnSearchAuthor').on('click', function (event) {
            event.preventDefault(); // prevent button click from submitting the form
            searchAuthor(1);
        });

        $('#authorModal').on('hide.bs.modal', function () {
            $('#txtSearchLastName').val('');
            $('#pnlAuthors').html('');
            $('#txtAuthors').val('');
            $('#lstAuthors li').each(function (i, li) {
                var authorCheckbox = $(li).contents()[0];
                var author = $(li).contents()[1];
                if ($(authorCheckbox).is(':checked')) {
                    if ($('#txtAuthors').val() != '') {
                        $('#txtAuthors').val($('#txtAuthors').val() + ",");
                    }
                    $('#txtAuthors').val($('#txtAuthors').val() + $(author).text());
                }
                else {
                    $(li).remove();
                }
            });
        });
    }

    return {
        initAuthorTable: initAuthorTable
    }

})(jQuery, Modernizr);