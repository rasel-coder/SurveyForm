
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

$('#searchBox').on('input', function () {
    const search = $(this).val();
    $.ajax({
        url: `/Templates/Template/SearchTemplate?search=${search}`,
        method: 'GET',
        success: function (data) {
            $('#results').empty();
            $('#results').html(data);
        }
    });
});



function updateAnswer(answerId, marks, maxMarks) {
    const data = {
        AnswerId: answerId,
        Marks: marks,
        MaximumMarks: maxMarks
    };
    console.log(data);

    $.ajax({
        url: '/Templates/Forms/UpdateAnswer',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (response) {
            console.log('Update successful:', response);
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}