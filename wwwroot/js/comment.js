
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/CommentHub")
    .build();

connection.stop().then(() => {
    connection.start()
        .then(function () {
            console.log("SignalR connection established.");
        })
});

$('#commentForm').on('submit', function (e) {
    e.preventDefault();

    const templateId = $('#comment-template-id').val();
    const commentText = $('#commentText').val();

    connection.invoke("AddComment", parseInt(templateId), commentText)
        .then(function (id) {
            $('#commentText').val('');
        })
        .catch(function (err) {
            console.error(err.toString());
        });
});

connection.on("CommentListUpdated", function (comments) {
    const commentPlaceholder = $('#template_comment_placeholder');
    commentPlaceholder.empty();

    //$.ajax({
    //    url: '/Templates/Template/GetComments',
    //    type: 'GET',
    //    data: { templateId: templateId },
    //    success: function (html) {
    //        console.log(html);
    //        commentPlaceholder.html(html);
    //    },
    //    error: function (err) {
    //        console.error("Failed to load comments:", err);
    //    }
    //});

    if (comments.length > 0) {
        comments.forEach(comment => {
            const commentHtml = `
                <div class="comment border p-3 rounded mb-3">
                    <p><strong>${comment.createdBy} -</strong> ${comment.commentText}</p>
                    <p><small>Posted on - ${new Date(comment.createdDate).toLocaleString()}</small></p>
                </div>
            `;
            commentPlaceholder.append(commentHtml);
        });
    } else {
        commentPlaceholder.html('<p>No comments yet. Be the first to comment!</p>');
    }
});