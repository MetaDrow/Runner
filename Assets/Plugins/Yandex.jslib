mergeInto(LibraryManager.library, {

	ShowAdv : function()
	{
		ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
			console.log("____closed____")
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
		}
		})
	},

});