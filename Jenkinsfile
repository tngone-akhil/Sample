node {
    // Define SonarScanner tool installation
    def scannerHome = tool name: 'SonarScanner', type: 'hudson.plugins.sonar.SonarRunnerInstallation'
    
    try {
        // Stage: Checkout
        stage('Checkout') {
            // Checkout your Git repository
            checkout scm
        }

        // Stage: Build
        stage('Build') {
            // Build the .NET project
            bat 'dotnet build bugtrackerapi.sln /p:Configuration=Release'
        }

        // Stage: Run SonarScanner
        stage('Run SonarScanner') {
            // Execute SonarScanner
            withSonarQubeEnv('SonarQubeServer') {
                bat "${scannerHome}/bin/sonar-scanner"
            }
        }
    } finally {
        // Clean up workspace
        deleteDir()
    }
}
