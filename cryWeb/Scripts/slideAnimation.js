var Slider = {
    go: function (cn) {
        $(cn).each(function () {
            var $btn = $('<button>hide</button>');
            $btn.click(function (event) {
                event.preventDefault();
                Slider.showHide(this);
            });
            $(this).children().first().append($btn);
            $(this).css('height', $(this).children().first().outerHeight() + 'px');
            Slider.animate(this, Slider.calcMaxHeight(this));
        });
    },

    calcMaxHeight: function (element) {
        var maxHeight = 0;
        $(element).children().each(function () {
            maxHeight += $(this).outerHeight();
        });

        return maxHeight;
    },

    showHide: function (btn) {
        var height = $(btn).parent().outerHeight();
        var $parent = $(btn).parent().parent();

        var down = $parent.outerHeight() == height;

        var maxHeight = 0;
        if (down) {
            maxHeight = this.calcMaxHeight($parent);
            $(btn).html('hide');
        }
        else {
            maxHeight = $parent.children().first().outerHeight();
            $(btn).html('show');
        }

        this.animate($parent, maxHeight);
    },

    animate: function (element, height) {
        $(element).animate({ height: height + 'px' });
    }
}





