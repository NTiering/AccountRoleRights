document.translations = document.translations || [];

document.translations["passord_match_missing"] = "Please supply a password";
document.translations["passord_match_mismatch"] = "Values don't match";

document.translate = function (key) {
    var rtn = document.translations[key] 
    return rtn ? rtn : "? " + key;
}