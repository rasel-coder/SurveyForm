
function questionTypeEvent(element) {
    if (element.value == 4) {
        $.ajax({
            url: '/Templates/Question/AddQuestionCheckbox?questionType=' + element.value,
            type: 'GET',
            success: function (data) {
                $("#question_checkbox_placeholder").html(data);
            },
            error: function (e) {
                alert("An error occurred while loading the modal." + e);
            }
        });
    }
    else {
        $("#question_checkbox_placeholder").html("");
    }
}

$('.saveQuestionBtn').on('click', function () {
    const url = $(this).data('url');
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            $("#addQuestion_modal_placeholder").html(data);
            $("#questionModal").modal('show');
        },
        error: function (e) {
            alert("An error occurred while loading Question Form modal. " + e.statusText);
        }
    });
});

function deleteQuestionConfirmation(TemplateId, QuestionId, QuestionTitle) {
    $('#delete_modal_template_id').val(TemplateId);
    $('#delete_modal_question_id').val(QuestionId);
    $('#delete_modal_question_title').html(QuestionTitle);
}