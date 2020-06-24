"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FilterPipe = /** @class */ (function () {
    function FilterPipe() {
    }
    /**
     * Transform
     *
     * @param {any[]} items
     * @param {string} searchText
     * @returns {any[]}
     */
    FilterPipe.prototype.transform = function (items, searchText) {
        if (!items) {
            return [];
        }
        if (!searchText) {
            return items;
        }
        searchText = searchText.toLocaleLowerCase();
        return items.filter(function (it) {
            return it.toLocaleLowerCase().includes(searchText);
        });
    };
    return FilterPipe;
}());
exports.FilterPipe = FilterPipe;
//# sourceMappingURL=filter.pipe.js.map