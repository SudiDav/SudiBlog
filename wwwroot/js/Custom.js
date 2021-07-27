let index = 0;

function AddTag() {
    var tagEntry = document.getElementById("TagEntry");

    // search empty or ducplicate tag

    let searchResult = search(tagEntry.value);
    if (searchResult != null) {
        // Trigger sweet Alert
        swalWithDarkButton.fire({
            html: `<span class = 'font-weight-bolder'>${searchResult.toLocaleUpperCase()}</span>`
        })
    }
    else {

        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }

    // clear the input
    tagEntry.value = "";
    return true;

}


function DeleteTag() {
    let tagcount = 1;
    let tagList = document.getElementById("TagList");
    if (!tagList) return false;

    if (tagList.selectedIndex == -1) {
        swalWithDarkButton.fire({
            html: `<span class="font-weight-bolder">CHOOSE A TAG BEFORE DELETING!</span>`
        });
        return true;
    }

    while (tagcount > 0) {
        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagcount;
        }
        else
            tagcount = 0;
        index--;
    }
}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

// check if the tagValues has data

if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let t = 0; t < tagArray.length; t++) {
        ReplaceTag(tagArray[t], t);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}

function search(str) {
    if (str == '') {
        return 'Empty tags are not permitted!';
    }

    var tagsEl = document.getElementById("TagList");
    if (tagsEl) {
        let options = tagsEl.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value === str) {
                return `The Tag #${str} was detected as duplicate and it is not permitted!`;
            }
        }
    }
}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-sm btn-danger btn-block m-2'
    },
    imageUrl: '/assets/img/ooops.jpg',
    timer: 3000,
    buttonsStyling: false
})
