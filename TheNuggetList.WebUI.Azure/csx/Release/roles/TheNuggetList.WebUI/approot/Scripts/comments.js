/// <reference path="jquery-1.4.4-vsdoc.js" />
$(document).ready(function () {

    var comments = new Comments();

    $("div.comments").each(function () {

        var container = $(this);

        $("form", container).submit(function (e) {
            e.preventDefault();

            var form = $(this);
            var action = form.attr("action");
            var hiddenContentObjectPK = $("input:hidden#ContentObjectPK", form);
            var hiddenContentTypeName = $("input:hidden#ContentTypeName", form);
            var textAreaContent = $("textarea#Content", form);
            
            var contentObjectPK = hiddenContentObjectPK.val();
            var contentTypeName = hiddenContentTypeName.val();
            var content = textAreaContent.val();

            comments.AddComment(action, content, contentObjectPK, contentTypeName, function (data) {

                var list = $("ul#CommentsList", container);

                if (data.Success == true) {
                    $(list).append("<li><p>" + content + "</p></li>");
                    textAreaContent.val('');
                }
                else {
                    alert(data.Message);
                }

            });

        });

    });
});


var Comments = function () {

    Comments.prototype.AddComment = function (url, comment, contentObjectPK, contentTypeName, onSuccess, onFail) {
        
        $.ajax({
            url: url,
            type: "post",
            data: { content: comment,
                    contentObjectPK: contentObjectPK, 
                    contentTypeName: contentTypeName                    
                   },
            success: onSuccess
        });
        
    }

}