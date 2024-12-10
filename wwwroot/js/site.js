
// ====================== Password Visibility =======================
$(".toggle-password").click(function () {
    $(this).toggleClass("fa-eye fa-eye-slash");
    input = $(this).parent().find("input");
    if (input.attr("type") == "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }
});
// ==================================================================

$('.access-mode').on('change', function () {
    if ($(this).attr('id') === 'option_specified_users') {
        $('#specifiedUsersField').show();
    } else {
        $('#specifiedUsersField').hide();
    }
});

// ========================= Image DropZone =========================
function imageDropZone(existingImagePath) {
    Dropzone.autoDiscover = false;

    var templateDropzone = new Dropzone("#templateDropzone", {
        url: "/Templates/Template/UploadImage",
        autoProcessQueue: true,
        maxFiles: 1,
        acceptedFiles: "image/jpeg,image/png",
        addRemoveLinks: true,
        dictDefaultMessage: "Drop your image here or click to upload",
        dictRemoveFile: "Remove",

        init: function () {
            var myDropzone = this;
            if (existingImagePath) {
                var mockFile = { name: "Existing Image", size: 12345 };

                myDropzone.emit("addedfile", mockFile);
                myDropzone.emit("thumbnail", mockFile, existingImagePath);
                myDropzone.emit("complete", mockFile);
                myDropzone.files.push(mockFile);

                $("#imagePath").val(existingImagePath);
            }
            this.on("success", function (file, response) {
                $("#imagePath").val(response.filePath);
            });

            this.on("removedfile", function (file) {
                $("#imagePath").val("");
            });
        },
    });
}
// ==================================================================

// ======================== Quill Editor ============================
function quillEditor(content) {
    const quill = new Quill('.descriptionEditor', {
        theme: 'snow',
        placeholder: 'About general knowledge'
    });
    quill.on('text-change', function (delta, oldDelta, source) {
        var editorContent = quill.root.innerHTML;
        $('#templateDescription').val(editorContent);
    });
    quill.root.innerHTML = content;
}
// ==================================================================

// ==================== Tagify - Tag management =====================
function templateTag(templateSpecificTags) {
    if (templateSpecificTags != null) {
        var subjectsArray = templateSpecificTags.split(',');
        var formattedValues = subjectsArray.map(function (subject) {
            return { value: subject.trim() };
        });
        $('.advance-options').val(JSON.stringify(formattedValues));
    }
}

var inputTags;
function templateTagSetup(tagsFromServer) {
    inputTags = document.querySelector('input.advance-options'),
        tagify = new Tagify(inputTags, {
            pattern: /^.{0,20}$/,
            delimiters: ",| ",
            keepInvalidTags: false,
            maxTags: 6,
            whitelist: tagsFromServer,
            dropdown: {
                enabled: 1,
                fuzzySearch: false,
                position: 'text',
                caseSensitive: false,
            }
        });

    tagify.on('change', function () {
        $('#hiddenTags').val(tagify.value.map(tag => tag.value).join(','));
        updatePlaceholderByTagsCount();
    });
}

function updatePlaceholderByTagsCount() {
    if (tagify.value.length == 0) {
        tagify.setPlaceholder(`Maximum 6 tags can be added`);
    } else {
        tagify.setPlaceholder(`${6 - tagify.value.length} are left`);
    }
}
// ==================================================================

// ===================== jQuery UI Drag and Drop ====================
$(function () {
    $(".sortQuestionList").sortable({
        update: function (event, ui) {
            let sortedItems = [];
            $('.sortQuestionList li:not(:first)').each(function (index) {
                sortedItems.push({
                    QuestionId: $(this).data("question-id"),
                    DisplayOrder: index + 1
                });
            });
            if (sortedItems) {
                $.ajax({
                    url: '/Templates/Question/SaveQuestionOrder',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(sortedItems),
                    success: function (response) {
                        console.log('Order saved successfully.');
                    },
                    error: function () {
                        alert('An error occurred while saving the order.');
                    }
                });
            }
        },
    });
    //$(".question-list").disableSelection();
});
// ===================================================================

// ============== Tagify for template specified users ================
function templateSpecificUsers(usersFromServer) {
    const input = document.querySelector('[name=template_specific_user_tags]');
    tagify = new Tagify(input, {
        whitelist: usersFromServer.map(({ UserId, UserName }) => ({ value: UserId, name: UserName, title: UserName })),
        enforceWhitelist: true,
        tagTextProp: 'name',
        dropdown: {
            position: "manual",
            maxItems: Infinity,
            enabled: 0,
            classname: "customSuggestionsList",
            searchKeys: ['name'],
            position: 'name',
            mapValueTo: 'name',
            searchKeys: ['name'],
        },
        templates: {
            dropdownItemNoMatch() {
                return `Nothing Found`;
            }
        },
        callbacks: {
            //add: ({ detail: { data } }) => console.log(data),
            change: () => {
                const tagifyValues = tagify.value.map(tag => ({
                    UserId: tag.value,
                    UserName: tag.name,
                }));
                $('input[name="TemplateSpecificUsers"]').val(JSON.stringify(tagifyValues));
            }
        }
    })
}




















const imgs = document.querySelectorAll('.img-select a');
const imgBtns = [...imgs];
let imgId = 1;

imgBtns.forEach((imgItem) => {
    imgItem.addEventListener('click', (event) => {
        event.preventDefault();
        imgId = imgItem.dataset.id;
        slideImage();
    });
});

function slideImage() {
    const displayWidth = document.querySelector('.img-showcase img:first-child').clientWidth;

    document.querySelector('.img-showcase').style.transform = `translateX(${- (imgId - 1) * displayWidth}px)`;
}

window.addEventListener('resize', slideImage);