function selectAuthor(event, author) {
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

function searchAuthor(startRow) {
    var searchType = $("input[name='rdoSearchType']:checked").val();
    var ajaxUrl = '/author/listbylastnamepaged/?lastName=';
    var searchTerm = $('#txtSearchLastName').val();
    var numberOfRows = 3;

    if (searchType == 'id') {
        ajaxUrl = '/author/listbyidpaged/?authorID=';
    }

    $.ajax({
        url: ajaxUrl + searchTerm + '&startRow=' + startRow + '&numberOfRows=' + numberOfRows,
        type: 'GET',
        cache: false,
        success: function (data) {
            $('#pnlAuthors').html(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log('error', textStatus, errorThrown);
        }
    });
}

//#region Ready
$(document).ready(function () {
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
});
//#endregion