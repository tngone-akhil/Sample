node {
    // Define the .NET SDK tool
    def dotnetTool = tool name: 'dotnet', type:  'hudson.plugins.dotnet.DotNetToolInstallation'

    stage('Checkout') {
        // Checkout your Git repository
        checkout scm
    }

    stage('Restore') {
        // Restore NuGet packages and project dependencies
        echo "${dotnetTool}"
        bat "${dotnetTool}/dotnet restore"
    }

    stage('Build') {
        // Build the .NET project
        bat "${dotnetTool}/dotnet build --configuration Release"
        
        // Archive the build artifacts (if needed)
        // Adjust the path based on your project structure
        // archiveArtifacts artifacts: 'bin/Release/**', allowEmptyArchive: true
    }

    stage('Test') {
        // Run tests if applicable
        bat "${dotnetTool}/dotnet test --no-restore"
    }

    stage('Publish') {
        // Publish the .NET application (if it's a web application, for example)
        bat "${dotnetTool}/dotnet publish --configuration Release --output publish_output"
        
        // Archive the published artifacts (if needed)
        // archiveArtifacts artifacts: 'publish_output/**', allowEmptyArchive: true
    }

    // stage('Deploy') {
    //     // Example deployment stage, adjust as per your deployment process
    //     bat 'xcopy /s publish_output\\*.* \\\\server\\path\\to\\deploy\\folder'
    // }

    stage('Cleanup') {
        // Clean up workspace
        deleteDir()
    }
}
