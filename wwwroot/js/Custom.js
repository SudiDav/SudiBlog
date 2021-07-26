let index = 0;

function AddTag() {
    var tagEntry = document.getElementById("TagEntry");

    let newOption = new Option(tagEntry.value, tagEntry.value);
    document.getElementById("TagList").options[index++] = newOption;

    // clear the input
    tagEntry.value = "";
    return true;

}


function DeleteTag() {
    let tagcount = 1;
    while (tagcount > 0) {
        let tagList = document.getElementById("TagList");
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
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
