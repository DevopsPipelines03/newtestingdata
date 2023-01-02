(function(window) {
  window.env = window.env || {};

  // Environment variables
  window["env"]["API_URL"] = "${API_URL}";
  window["env"]["APPLICATIONINSIGHTS_INSTRUMENTATION_KEY"] = "${APPLICATIONINSIGHTS_INSTRUMENTATION_KEY}";
})(this);