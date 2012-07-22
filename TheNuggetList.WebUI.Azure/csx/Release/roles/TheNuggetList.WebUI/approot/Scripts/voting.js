/// <reference path="jquery-1.4.4-vsdoc.js" />

function AjaxVote(url, voteDiv) {
    
    function CastVote(event) {
        event.preventDefault();
        $.ajax({
            url: url,
            type: "get",
            success: function (data) {
                $("span.vote-count", voteDiv).text(data.count);  
            }
        });
    }

    return CastVote;
}

$(document).ready(function () {
    $("div.vote").each(function () {
        var votingDiv = $(this);
        $("a", votingDiv).each(function () {
            var anchor = $(this);
            var url = anchor.attr("rel");
            anchor.click(AjaxVote(url, votingDiv));
        });
    });
})