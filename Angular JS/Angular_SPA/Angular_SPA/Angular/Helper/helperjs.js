function convertToCamelCase(word) {
    if (word == null || word == undefined)
        return;
    return word.charAt(0).toUpperCase() + word.slice(1);
}